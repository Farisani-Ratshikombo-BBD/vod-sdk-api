# pull nginx image
FROM nginx:1.19.0-alpine

# Install Certbot
RUN apk add --no-cache certbot

RUN rm /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose ports
EXPOSE 80
EXPOSE 443

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
