FROM nginx:alpine

#  default conf for proxy service
COPY src/Gateways/Lemoras.Remora.Gateway.Base/nginx.conf /etc/nginx/nginx.conf

# NOT FOUND response
COPY src/Gateways/Lemoras.Remora.Gateway.Base/backend-not-found.html /var/www/html/backend-not-found.html

# Proxy configurations
COPY src/Gateways/Lemoras.Remora.Gateway.Base/includes/ /etc/nginx/includes/

EXPOSE 80