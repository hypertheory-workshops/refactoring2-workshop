FROM node:14.16-alpine AS build
WORKDIR /dist/src/app

RUN npm cache clean --force
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:1.21.3 AS ngi
COPY --from=build /dist/src/app/dist/few300 /usr/share/nginx/html
COPY /nginx.conf  /etc/nginx/conf.d/default.conf
# Exposing a port, here it means that inside the container
# the app will be using Port 80 while running
EXPOSE 80
