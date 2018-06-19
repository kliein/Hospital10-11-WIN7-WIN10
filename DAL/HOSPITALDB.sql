--创建传感器接收病人信息数据表
use HOSPITALDB
go
if exists (select * from sysobjects where name='Patients')
drop table Patients
go
create table Patients
(
    ID int identity(1,1)  primary key,
    PatientBednum int ,
    PatientName varchar(20),
    PatientGender char(2),
    PatientAge int,
    PatientDepartment varchar(50),
    PatientNum varchar(30),
    Patientstarttime smalldatetime,
    Patientendtime smalldatetime,
    UseFlag int,
    --BloodO2 int,
    --Pluse int,
    --GetO2time int,
    --Flux varchar(10),
    --AutoFlux varchar(10),
    --HandFlux varchar(10),
    --GetO2totaltime int,
)
go


use HOSPITALDB
go

if exists (select * from sysobjects where name='PatientBodyInfo')
drop table PatientBodyInfo
go

create table PatientBodyInfo
(
    flag int  primary key identity(1,1),
    PatientBodyInfotime smalldatetime default(getdate()),
    PatientBednum int,
    BloodO2 int,
    Pluse int,
    GetO2time int,
    Flux varchar(10),
    Model varchar(10),
    Error varchar(10),
    GetO2totaltime int,
    UseFlag int,
)
go





use HOSPITALDB
go
if exists (select * from sysobjects where name='BedConfig')
drop table BedConfig
go
create table BedConfig
(
    Bedflag int identity(1,1),
    Bedcount int  primary key,
    Bedrows int,
)
go

use HOSPITALDB
go
if exists (select * from sysobjects where name='SetInfo')
drop table SetInfo
go
create table SetInfo
(
    ID int identity(1,1)  primary key,
    PatientBednum int ,   
    IsEnable int,
    UseFlag int,
)
go

update Patients set UseFlag = 1 where PatientBednum=1



select PatientName,Patientstarttime,Patientendtime,PatientNum from Patients where PatientBednum=1 and UseFlag=1

select *from Patients where UseFlag=0

select PatientBednum,PatientName,PatientGender,PatientAge,PatientDepartment,PatientNum,Patientstarttime from Patients where UseFlag=0

select * from Patients
select * from SetInfo
select * from PatientBodyInfo
DELETE FROM SetInfo WHERE PatientBednum =4
DELETE FROM PatientBodyInfo WHERE PatientBednum =1
--	update Patients set PatientName='张五',PatientGender='女',Patienttime='2017-07-21 11:19:00',PatientAge=62,PatientDepartment='外科',PatientNum='1001' where PatientBednum=2	
insert into PatientBodyInfo(PatientBednum,BloodO2,Pluse,GetO2time,Flux,Model,Error,GetO2totaltime,UseFlag) values (1,96,88,12,6,'手动','无',20,0)

select Patients.PatientName,PatientBodyInfo.PatientBodyInfotime,PatientBodyInfo.BloodO2,PatientBodyInfo.Pluse,PatientBodyInfo.GetO2time,PatientBodyInfo.Flux,Model,PatientBodyInfo.Error,PatientBodyInfo.GetO2totaltime from PatientBodyInfo, Patients where  PatientBodyInfo.PatientBednum=3 and Patients.PatientBednum=3
	