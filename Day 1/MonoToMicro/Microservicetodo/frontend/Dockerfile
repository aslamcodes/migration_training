FROM node:18-alpine

WORKDIR /app

COPY package.json pnpm-lock.yaml ./

RUN npm install -g pnpm && pnpm install

COPY . .

RUN pnpm run build

CMD ["pnpm", "run", "preview", "--host"]

EXPOSE 4173

