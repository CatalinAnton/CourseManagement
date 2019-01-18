# CourseManagement
dotNet 2018-2019 project

### Authors ###

* **Anton Catalin**
* **Apuscasitei Silviu Alexandru**
* **Bojescu Mihai**
* **Cochior-Heghi Lucian**
* **Feciuc Stelian-Teodor**


### Description ###


### Tools ###
 (use initMongoDB.bat to configure MongoDB for this project)


# CourseManagement

Web Application that provides the possibility to manage your study courses both as a lecturer and as an attendant. The product is designed to manage __course resources__, put and answer to questions and give explanations in the __chat__, and to be subscribed and get notified when your favorite courses are uploading new content.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development .

### Prerequisites

What things you need to install:
* [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2) - Backend
* [MongoDB Community Server 4.0.4](https://www.mongodb.com/download-center) - Database
* [Reactjs 16.6.0](https://5c11762d4be4d10008916ab1--reactjs.netlify.com/versions) - JS Framework


### Installing
.NET Core 2.2:
 * download and install
 * be sure to have it in the PATH system variable

MongoDB Community Server 4.0.4:
 * download and install
 * run initMongoDB.bat to configure the project's database with root permisions
 
 Reactjs 16.6.0:
 * download and install
 * be sure to have node installed
 * run it in WebAPI/ClientApp
```
npm install --save
```




## Building and running
Build and run the APIs of the project by typing
```
dotnet run
```
on AuthAPI, ChatAPI, CourseAPI, ResourseAPI, SubscribeAPI, WebAPI



## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

