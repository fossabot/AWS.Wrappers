﻿
# AWS Wrappers S3 (AWSWS3)

[![CodeFactor](https://www.codefactor.io/repository/github/bhuvaneshsaha/aws.wrappers/badge/s3-wrapper-upgrade)](https://www.codefactor.io/repository/github/bhuvaneshsaha/aws.wrappers/overview/s3-wrapper-upgrade)

[![.NET](https://github.com/bhuvaneshsaha/AWS.Wrappers/actions/workflows/dotnet.yml/badge.svg)](https://github.com/bhuvaneshsaha/AWS.Wrappers/actions/workflows/dotnet.yml)

AWS Wrappers is a straightforward **.NET 6 C# class library** to perform basic operations AWS S3 from the .NET core application which is built on top of AWS libraries, which Amazon Web Services provide.

The AWS libraries provide all the features needed to perform operations with AWS, but they are sometimes not straight forward to use and we need to implement them in our application.

So, AWS Wrappers S3 is designed to do basic operations such as creating buckets, uploading files, creating folders, etc. with the AWS Simple Storage Services (S3) with simple, user-readable methods that already implement the codes required to perform the operation.

## Usage
Clone the code from the master branch or download stable release from the release area.

You can copy the `AWS.Wrappers.S3` class library into your project solution folder and add references (dependencies) to their project, then you can utilize the library.

If you prefers to have the wrapper classes in your own project, you can simply copy the necessary interfaces and classes into your projects and start working with them.

> The library contains both synchronous and asynchronous methods.

Package which need to be imported,
```
using AWS.Wrappers.S3.Interfaces;
using AWS.Wrappers.S3.Services;
```

Creating S3Service Object,

```
IS3Service _S3Service = new S3Service("<AccessKey>", "<SecretKey>", S3Regions.USEast1);
```

Sample code to create bucket in AWS S3 with S3 Wappers,

_In synchronous,_
```
    IS3Service S3Service = new S3Service("<AccessKey>", "<SecretKey>", S3Regions.USEast1);
    S3Service.CreateBucket("<new-bucket-name>");
```

_In asynchronous,_
```
    IS3Service S3Service = new S3Service("<AccessKey>", "<SecretKey>", S3Regions.USEast1);
    await S3Service.CreateBucketAsync("<new-bucket-name>");
```

> Please see the list of methods available in the [Methods list](AWS.Wrappers.S3/Versions/S3WrapperMethodsList.md).

> You can find the version info/change log in the following links:
>>[Version 1.0.0](AWS.Wrappers.S3/Versions/V1_0_0.md)

## Roadmap

- [X] Ability to run all unit tests at once
- [ ] Supports KMS

## Contribution

Contibution is always welcome. If you would like to contribute to this project, please contact bhuvaneshmib@gmail.com.
