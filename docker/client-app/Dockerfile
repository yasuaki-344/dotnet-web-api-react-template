# build environment
FROM node:16-alpine3.14 AS build

WORKDIR /app
RUN npm install --location=global npm --upgrade
COPY src/ClientApp/package.json ./
COPY src/ClientApp/package-lock.json ./
RUN npm i

COPY ./src/ClientApp ./
RUN npm run build

# runtime envrionment
FROM nginx:1.22.0-alpine
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=build /app/dist .

ENTRYPOINT ["nginx", "-g", "daemon off;"]
