FROM node:14.17.0-alpine as develop-stage
WORKDIR /
COPY package*.json ./
RUN npm install -g npm@latest
RUN yarn install
COPY . .
EXPOSE 8084
CMD ["node"]

# ���������� ����������� ����� Node.js
#FROM node:lts AS build
#
## ������������� ������� ���������� ������ ����������
#WORKDIR .
#
## �������� ����� ������������
#COPY package*.json .
#
## ������������� �����������
#RUN npm install -g npm@latest
#
## �������� ��������� ����� �������
#COPY . .
#
## �������� ����������
#RUN npm run build
#
## ��������� ����: ����������� Nginx ��� ������� ����������� ������ Vue.js
#
## ���������� ����������� ����� Nginx
#FROM nginx:stable-alpine as production-stage
#
## �������� ��������� ����������� ����� Vue.js �� ����������� ����� � ���������� ������� Nginx
#COPY --from=build /dist /usr/share/nginx/html
#
## ���������� ���� ������������ ���� �� ��������� (80), ���� ��������� ��� � ������ ���������
#EXPOSE 80
#
## ������� ��� ������� Nginx ������ ����������
#CMD ["nginx", "-g", "daemon off;"]
#