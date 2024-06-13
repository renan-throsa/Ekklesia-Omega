# Step 1: Build the app in node container
FROM node:14 as build

WORKDIR /app

COPY package.json package-lock.json ./

RUN npm install

RUN npm install -g @angular/cli@14

COPY . .

RUN npm run build --prod

FROM node:14 AS serve

WORKDIR /app

COPY --from=build /app/dist/ekklesia ./dist

COPY server.js ./

RUN npm install express

EXPOSE 3000

CMD ["node", "server.js"]


