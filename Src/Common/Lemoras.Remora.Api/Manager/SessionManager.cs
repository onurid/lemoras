﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Lemoras.Remora.Core;
using Lemoras.Remora.Core.Manager;
using Lemoras.Remora.Core.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Api.Manager
{
    public class SessionManager : ISessionManager
    {
        private readonly ICacheManager cacheManager;

        public SessionManager()
        {
            this.cacheManager = Invoke<ICacheManager>.Call();
        }
        

        public UserSession GetCurrentSession(string token)
        {
            return cacheManager.Get<UserSession>(token);
        }
        
        public static void SetSessionAsManager(IServiceCollection services)
        {
            services.AddCors(config =>
            {
                var policy = new CorsPolicy();
                policy.Headers.Add("*");
                policy.Methods.Add("*");
                policy.Origins.Add("*");
                policy.SupportsCredentials = true;
                config.AddPolicy("policy", policy);
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //IssuerSigningKey = new RsaSecurityKey(new RSACryptoServiceProvider(2048).ExportParameters(true)),
                    ValidateAudience = false,
                    //ValidAudience = "lemoras.com",
                    ValidateIssuer = false,
                    //ValidIssuer = "onuryasar.org",
                    //ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("xxx"))
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = ctx =>
                    {

                        var mngr = Invoke<ISessionManager>.Call();

                        StringValues a;

                        if (!ctx.Request.Headers.TryGetValue("Authorization", out a))
                        {
                            ctx.Response.StatusCode = 401;

                            return Task.FromCanceled(new System.Threading.CancellationToken(true));
                        }

                        var token = a[0].Replace("Bearer ", "");
                        //TODO: Token decode edilerek session bilgileri alınacak.
                        
                        //var result = mngr.GetCurrentSession(token);

                        //if (string.IsNullOrEmpty(result.UserName))
                        //{
                        //    ctx.Response.StatusCode = 401;
                        //    return Task.FromCanceled(new System.Threading.CancellationToken(true));
                        //}

                        TokenContextService.Token = token;

                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = ctx =>
                    {
                        Console.WriteLine("Exception:{0}", ctx.Exception.Message);
                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void SetAuthAndPolicy(IApplicationBuilder app)
        {
            app.UseCors("policy");
            app.UseAuthentication();
        }
    }
}