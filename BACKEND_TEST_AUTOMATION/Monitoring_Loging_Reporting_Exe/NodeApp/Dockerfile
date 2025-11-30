FROM node:18

WORKDIR /home/node/app

COPY package*.json ./

RUN npm ci

COPY . .

EXPOSE 8085

CMD ["npm", "start"]
