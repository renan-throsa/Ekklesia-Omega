FROM node:16-alpine as build

WORKDIR /app

COPY Ekklesia.Spa/package.json Ekklesia.Spa/package-lock.json ./

RUN npm install

COPY ./Ekklesia.Spa .
RUN ls -la

RUN npm run build --prod


FROM node:16-alpine
WORKDIR /app
COPY --from=build /app/dist ./dist
RUN npm install -g @angular/cli@13
EXPOSE 4200
CMD ["ng", "serve", "--host", "0.0.0.0"]
