
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
# README

Добрый день! С вами Амир, а это краткая инструкция по ***правильной*** настройке и запуску, казалось бы, тестовой, но интересной работы! **ПРИСТУПИМ!**

Итак,**первое**,что нужно сделать - стянуть репозиторий, однако, если вы попали сюда, то сразу переходим ко второму пункту + 
А именно, запуску SQL скриптов на языке Transact SQL, который очень похож на SQL, ладно, это он и есть, просто в нотации Microfost, из папки ScriptsToAddDataTables.
Сначала CREATE, потом INSERT, всё как обычно

Чтож, почти всё, можно запускать sln:
Состоит из двух проектов - Server и Client, тем самым реализует клиент-серверную архитектуру при помощи фреймворка WFC
На сервере происходит вся работа с БД и данными, на клиенте происходит опрос пользователя и обработка полученной от сервера информации
Для верного функционирования нужно изменить Properties у PetClinicVitakor.sln, а именно сделать так, чтобы сервер и клиент запускались и работали вместе
Для этого нужно проставить одновременный запуск (Multiple startup projects) для клиента и сервера

Тащемта и всё, после запуска клиент будет опрашивать пользователя, представляя аналог пользовательского интерфейса
Есть возможность добавлять новые записи в некоторые таблицы, а так же просматривать их содержимое, функционал расширяем

# Спасибо за внимание!    

А вот и само тестовое задание 
1) Построить реляционную базу данных ветеринарной клиники:
Структура базы данных может быть любая
База данных должна содержать по меньшей мере информацию о:
а) Животных
б) Докторах
в) Хозяевах
г) Услугах
д) Прививках
Для построения разрешено использовать любые инструменты и реляционные СУБД
2) Реализовать приложение для работы с базой данных:
Для реализации рекомендуется использовать:
а) Клиент-сервеную архитектуру
б) .NET Framework не позднее версии 4.0
Приложение может быть как web так и desktop
![CAT](https://kotikdoma.com/wp-content/uploads/2019/11/img_5ddebd7d0c34a.jpg)
