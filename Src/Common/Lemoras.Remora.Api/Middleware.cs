using System;
using System.Text;
using System.Threading.Tasks;
using Lemoras.Remora.Core.Factory;
using Lemoras.Remora.Core.Manager;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OYASAR.Framework.Core;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Manager;
using OYASAR.Framework.Core.Utils;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Api
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            ILog log = null;

            var returnResult = new Result();

            byte[] data = null;

            try
            {
                log = Invoke<IManagerFactory>.Call().GetLogManger();
                using (IocManager.Instance.BeginScope())
                {
                    if (!context.Request.Path.Value.Contains("/ping"))
                        RoleManager.IsAccess();

                    await _next(context);
                }
            }
            catch (BusinessException ex)
            {
                returnResult = Result.Error(new Error { Message = ex.Message });
                data = GetContentBody(returnResult);
            }
            catch (Exception ex)
            {
                var firstExp = ex.GetBaseException();

                if (firstExp.Source.Contains("Lemoras") && firstExp.Source.Contains("Business"))
                {
                    returnResult = Result.Error(new Error { Message = firstExp.Message });
                }
                else
                {
                    if (log == null)
                    {
                        returnResult = Result.Error(new Error
                        { Message = Constants.Message.Exception.LogObjectIsNull });
                    }
                    else
                    {
                        log.Write(ex);
                        returnResult = Result.Error(new Error
                        { Message = Constants.Message.Exception.UnkownError });
                    }
                }

                data = GetContentBody(returnResult);
            }
            finally
            {
                if (log != null)
                    log.Write(returnResult);
            }

            if (data != null)
            {
                context.Response.ContentType = "application/json";
                context.Response.Body.Write(data, 0, data.Length);
            }
            await Task.CompletedTask;
        }

        private static byte[] GetContentBody(object obj)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new LowercaseContractResolver();
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }
    }
}