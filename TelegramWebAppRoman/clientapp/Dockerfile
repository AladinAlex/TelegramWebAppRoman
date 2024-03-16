FROM node:14.17.0-alpine as develop-stage
WORKDIR /
COPY package*.json ./
RUN npm install -g npm@latest
RUN yarn install
COPY . .
EXPOSE 8084
CMD ["node"]

# Используем официальный образ Node.js
#FROM node:lts AS build
#
## Устанавливаем рабочую директорию внутри контейнера
#WORKDIR .
#
## Копируем файлы зависимостей
#COPY package*.json .
#
## Устанавливаем зависимости
#RUN npm install -g npm@latest
#
## Копируем остальные файлы проекта
#COPY . .
#
## Собираем приложение
#RUN npm run build
#
## Следующий этап: настраиваем Nginx для раздачи статических файлов Vue.js
#
## Используем официальный образ Nginx
#FROM nginx:stable-alpine as production-stage
#
## Копируем собранные статические файлы Vue.js из предыдущего этапа в директорию раздачи Nginx
#COPY --from=build /dist /usr/share/nginx/html
#
## Необходимо либо использовать порт по умолчанию (80), либо настроить его в другой доступный
#EXPOSE 80
#
## Команда для запуска Nginx внутри контейнера
#CMD ["nginx", "-g", "daemon off;"]
#