# Step 1: Build the app in node container
FROM node:14 as build

WORKDIR /app

COPY package.json package-lock.json ./

RUN npm install

RUN npm install -g @angular/cli@14

COPY . .

RUN npm run build --prod

FROM nginx:1.19.0-alpine AS serve

COPY --from=build /app/dist/ekklesia /usr/share/nginx/html

COPY ./nginx-custom.conf /etc/nginx/conf.d/default.conf

EXPOSE 4200

CMD ["nginx", "-g", "daemon off;"]

