use master
go
------------NewDb  目前总共有35张表

if exists(select 1 from sys.databases where name='db_gblz')
begin
	drop database db_gblz
end
create database db_gblz
go
use db_gblz
go

----8张表

--用户登录记录表（DT_UserLoginRecord）		
if exists(select 1 from sys.objects where name='DT_UserLoginRecord')
begin
	drop table DT_UserLoginRecord
end
create table DT_UserLoginRecord
(
	Id	int primary key identity,	--id
	Telphone 	nvarchar(20),	--手机号码(就是用户名)
	Password	nvarchar(50),	--密码
	LoginTime	Datetime,	--登录时间
	LoginIp	Varchar(20),	--登录IP
	LoginNum	int,	--登录次数
	Remark	Varchar(40),	--备注
	RoleId	int,	--角色Id
	IsInner 	bit,	--是否系统内部成员
	IsCadre	bit default 'false' ,	--是否科级干部
	WorkUnitId	int,	--单位名称id
	DeptId	int,	--科室id
	Effectivedate	datetime,	--有效期（填表有效期）
	Status	bit,	--账号状态（账号是否禁用）
	RealName	nvarchar(50),	--真实姓名
	WorkUnit	nvarchar(50),	--单位名称
	Department	nvarchar(50),	--科室名称
	Upost nvarchar(50),--职务
	FillStatus	nvarchar(50),	--填表状态
	ShareStatus	nvarchar(50),	--共享状态
	
	AddTime datetime,--添加时间
	UpdateTime datetime--修改时间
)
--e10adc3949ba59abbe56e057f20f883e  YisaaAdmin.             E1ADC3949BA59ABBE56E057F2F883E
insert into DT_UserLoginRecord(Telphone,Password,RoleId,IsInner,IsCadre,Status,RealName) values('YisaaAdmin.','e10adc3949ba59abbe56e057f20f883e',4,'true','true','true','小易')
select * from DT_UserLoginRecord

select * from DT_Total
 
select * from DT_UserInfo

--工作单位表(DT_WorkUnit) 		
if exists(select 1 from sys.objects where name='DT_WorkUnit')
begin
	drop table DT_WorkUnit 
end
create table DT_WorkUnit
( 
	Id	 int primary key identity,	--id
	UnitName	nvarchar(50),	--单位名称
	ParentId	int, 	--父级id
	CreateUnit  	nvarchar(50),	--创建单位的人
	CreateDept  	nvarchar(50),	--创建科室的人
	AddUnitTime 	datetime,	--添加单位的时间
	AddDeptTime 	datetime,	--添加科室的时间
	UpdUnitTime 	datetime,	--修改单位的时间 
	UpdDeptTime 	datetime,	--修改科室的时间	
	Remarks	nvarchar(255) 	--备注
)
select * from DT_WorkUnit
	
--单位/科室变更表(DT_DeptChange)		
if exists(select 1 from sys.objects where name='DT_UnitDeptChange')
begin
	drop table DT_UnitDeptChange
end
create table DT_UnitDeptChange
(
	Id	int	primary key identity, --id
	UserId	int,	--用户登录id
	UnitName	nvarchar(50),	--原工作单位
	DeptName	nvarchar(50),	--原科室
	AddTime	datetime,	--变更时间
	Remarks	nvarchar(150)	--备注

)

--角色表（DT_Role）		
if exists(select 1 from sys.objects where name='DT_Role')
begin
	drop table DT_Role
end
create table DT_Role
(
	Id	int primary key identity,	--id
	Name	nvarchar(50),	--角色名称
	Remark	nvarchar(100)	--备注		
)
select * from DT_Role

	
	
--共享表（DT_Share）	
if exists(select 1 from sys.objects where name='DT_Share')
begin
	drop table DT_Share
end
create table DT_Share
(
	Id	int primary key identity, 	--id
	BeSharedPeople	nvarchar(50),	--被共享人（已经归档的科级干部）
	SharedYear	int,	--共享年份
	ShareBeginTime	datetime,	--共享开始时间
	ShareEndTime	datetime,	--共享结束时间
	SharePeople	nvarchar(50),	--共享人(系统内、系统外)
	CreateTime 	datetime,	--创建时间	
	
	BeSharedId 	int,--被共享人id
	ShareId int --共享人id
	
)	
select * from DT_Share

select BeSharedId from DT_Share where ShareId=5

select * from DT_Share where ShareId=5
select * from DT_Share where ShareId=13
--根据传进来的shareid查询到BeShareId的集合
--根据传进来的shareid查询到最新一条记录
	
--被共享人表（DT_BeShared）	
if exists(select 1 from sys.objects where name='DT_BeShared')
begin
	drop table DT_BeShared
end
create table DT_BeShared
(
	Id	int primary key identity, 	--id
	BeSharedId	int	--被共享人（已经归档的科级干部）
)
select * from DT_BeShared

	
--共享人表（DT_SharePeople）	
if exists(select 1 from sys.objects where name='DT_SharePeople')
begin
	drop table DT_SharePeople
end
create table DT_SharePeople
(
	Id	int primary key identity, 	--id
	ShareId	int,	--共享人(系统内、系统外)
	TotalId int
)
select * from DT_SharePeople

	
--建档时间表（DT_BuildTime）	 
if exists(select 1 from sys.objects where name='DT_BuildTime')
begin
	drop table DT_BuildTime
end
create table DT_BuildTime
(		
	Id	int primary key identity, 	--id
	BuildStartTime	datetime,	--建档开始时间
	BuildEndTime	datetime,	--建档结束时间
	AddTime	datetime,	--添加时间
	UpdateTime	datetime,	--修改时间
	Remark	nvarchar(100)	--备注
)
select * from DT_BuildTime
--2	2017-06-22 00:00:00.000	2018-07-21 00:00:00.000	2017-06-22 16:09:01.867	2018-07-14 09:26:01.960	NULL
	
--总表（DT_Total）所有的登记表	156字段		
if exists(select 1 from sys.objects where name='DT_Total')
begin
	drop table DT_Total
end
create table DT_Total
(	
	Id	int primary key identity,--id
	UserId	int,	--用户登录id
	YearTable int, --年份
	AddTime datetime,--添加时间
	UpdTime datetime,--修改时间  
			
	Status nvarchar(15),   --状态（未提交、已提交、被退回，已归档）
	CheckStatus nvarchar(15),  --审核状态（1待审核、2已退回、3已提交、4被退回，已归档）
	FileStatus  nvarchar(15), --归档状态（待归档、已退回、已归档）
	
	BackTime datetime,--审核用户退回时间
	ChkSubmitTime	datetime, --审核用户提交党委时间
	HighBackTime datetime,--高级用户退回时间
	HighFileTime	datetime, --高级用户归档时间	

	UserInfoId	int, 	--用户基本信息表
	FamilyId	int, 	--家庭成员表
	RewardId	int, 	--奖惩情况登记表
	RefuseGiftId	int ,	--拒收或上交礼金登记表
	ProfitId	int, 	--参与营利及兼职持股情况报告表
	HousingId	int, 	--干部本人、配偶及共同生活的子女住房情况报告表
	MarryChangeId	int ,	--干部婚姻变化情况报告表
	WeddingandDieId	int, 	--干部操办本人及近亲婚丧喜庆事宜情况报告表
	GoAbroadId	int, 	--干部本人、配偶、子女及其配偶出国情况报告表
	CrimeId	int ,	--干部配偶、子女涉嫌犯罪情况报告表
	IndustryChangesId	int, 	--干部本人、配偶从业变更情况报告表
	ImportantId	int ,	--干部其他重大事项报告表
	ResponsibilityId	int,	--干部违纪违规处理及追究报告表
	PetitionLetterId	int, 	--干部信访核查情况表
	AdmonishingTalkId	int, 	--干部接受诫勉谈话情况登记表
	IncorruptTalkId	int, 	--干部接受廉政谈话情况登记表
	ApplyByLetterId	int, 	--干部接受函询情况登记表
	
	UserInfoAdvice1	nvarchar(100), 	--审核用户审核意见 _用户基本信息表
	FamilyAdvice1	nvarchar(100), 	--家庭成员表 
	RewardAdvice1	nvarchar(100), 	--审核用户审核意见 奖惩情况登记表
	RefuseAdvice1	nvarchar(100),	--审核用户审核意见 拒收或上交礼金 
	ProfitAdvice1	nvarchar(100), 	--审核用户审核意见 参与营利及兼职持股 
	HousingAdvice1	nvarchar(100), 	--审核用户审核意见 干部本人、配偶及共同生活的子女住房  
	MarryChgAdvice1	nvarchar(100) ,	--审核用户审核意见 干部婚姻变化情况报告表
	WeddDieAdvice1	nvarchar(100), 	--审核用户审核意见 干部操办本人及近亲婚丧喜庆事宜情况 
	AbroadAdvice1	nvarchar(100), 	--审核用户审核意见 干部本人、配偶、子女及其配偶出国情况 
	CrimeAdvice1	nvarchar(100) ,	--审核用户审核意见 干审核用户审核 部配偶、子女涉嫌犯罪情况 
	IndustryAdvice1	nvarchar(100), 	--审核用户审核意见 干部本人、配偶从业变更 
	ImportantAdvice1 nvarchar(100) ,  --审核用户审意见核 干部其他重大事项 
	ResponsAdvice1	nvarchar(100),	--审核用户审核意见 干部违纪违规处理及追究 
	LetterAdvice1	nvarchar(100), 	--审核用户审核意见 干部信访核查 
	AdmTalkAdvice1	nvarchar(100), 	--审核用户审核意见 干部接受诫勉谈话 
	IncTalkAdvice1	nvarchar(100), 	--审核用户审核意见 干部接受廉政谈话 
	ApplyAdvice1	nvarchar(100), 	--审核用户审核意见 干部接受函询情况 
	
	UserInfoAdvice2	nvarchar(100), 	--高级用户审核意见 _用户基本信息表
	FamilyAdvice2	nvarchar(100), 	--家庭成员表 
	RewardAdvice2	nvarchar(100), 	--高级用户审核意见 奖惩情况登记表 
	RefuseAdvice2	nvarchar(50),	--高级用户审核意见 拒收或上交礼金 
	ProfitAdvice2	nvarchar(100), 	--高级用户审核意见 参与营利及兼职持股 
	HousingAdvice2	nvarchar(100), 	--高级用户审核意见 干部本人、配偶及共同生活的子女住房 
	MarryChgAdvice2	nvarchar(100) ,	--高级用户审核意见 干部婚姻变化 
	WeddDieAdvice2	nvarchar(100), 	--高级用户审核意见 干部操办本人及近亲婚丧喜庆事宜 
	AbroadAdvice2	nvarchar(100), 	--高级用户审核意见 干部本人、配偶、子女及其配偶出国 
	CrimeAdvice2	nvarchar(100) ,	--高级用户审核意见 干审核用户审核 部配偶、子女涉嫌犯罪 
	IndustryAdvice2	nvarchar(100), 	--高级用户审核意见 干部本人、配偶从业变更 
	ImportantAdvice2 nvarchar(100) ,  --高级用户审意见核 干部其他重大事项 
	ResponsAdvice2	nvarchar(100),	--高级用户审核意见 干部违纪违规处理及追究 
	LetterAdvice2	nvarchar(100), 	--高级用户审核意见 干部信访核查 
	AdmTalkAdvice2	nvarchar(100), 	--高级用户审核意见 干部接受诫勉谈话 
	IncTalkAdvice2	nvarchar(100), 	--高级用户审核意见 干部接受廉政谈话 
	ApplyAdvice2	nvarchar(100), 	--高级用户审核意见 干部接受函询 
	
	UserInfoTime1	datetime, 	--审核用户审核时间 _用户基本信息表
	FamilyTime1	datetime, 	--家庭成员表 
	RewardTime1	datetime, 	--审核用户审核时间 奖惩情况登记表
	RefuseTime1	datetime ,	--审核用户审核时间 拒收或上交礼金 
	ProfitTime1	datetime, 	--审核用户审核时间 参与营利及兼职持股 
	HousingTime1	datetime, 	--审核用户审核时间 干部本人、配偶及共同生活的子女住房  
	MarryChgTime1	datetime ,	--审核用户审核时间 干部婚姻变化情况报告表
	WeddDieTime1	datetime, 	--审核用户审核时间 干部操办本人及近亲婚丧喜庆事宜情况 
	AbroadTime1	datetime, 	--审核用户审核时间 干部本人、配偶、子女及其配偶出国情况 
	CrimeTime1	datetime ,	--审核用户审核时间 干审核用户审核 部配偶、子女涉嫌犯罪情况 
	IndustryTime1	datetime, 	--审核用户审核时间 干部本人、配偶从业变更 
	ImportantTime1 datetime ,  --审核用户审核时间 干部其他重大事项 
	ResponsTime1	datetime,	--审核用户审核时间 干部违纪违规处理及追究 
	LetterTime1	datetime, 	--审核用户审核时间 干部信访核查 
	AdmTalkTime1	datetime, 	--审核用户审核时间 干部接受诫勉谈话 
	IncTalkTime1	datetime, 	--审核用户审核时间 干部接受廉政谈话 
	ApplyTime1	datetime, 	--审核用户审核时间 干部接受函询情况 
	
	UserInfoTime2	datetime, 	--高级用户审核时间 _用户基本信息表
	FamilyTime2	datetime, 	--家庭成员表 
	RewardTime2	datetime, 	--高级用户审核时间 奖惩情况登记表
	RefuseTime2	datetime ,	--高级用户审核时间 拒收或上交礼金 
	ProfitTime2	datetime, 	--高级用户审核时间 参与营利及兼职持股 
	HousingTime2	datetime, 	--高级用户审核时间 干部本人、配偶及共同生活的子女住房  
	MarryChgTime2	datetime ,	--高级用户审核时间 干部婚姻变化情况报告表
	WeddDieTime2	datetime, 	--高级用户审核时间 干部操办本人及近亲婚丧喜庆事宜情况 
	AbroadTime2	datetime, 	--高级用户审核时间 干部本人、配偶、子女及其配偶出国情况 
	CrimeTime2	datetime ,	--高级用户审核时间 干审核用户审核 部配偶、子女涉嫌犯罪情况 
	IndustryTime2	datetime, 	--高级用户审核时间 干部本人、配偶从业变更 
	ImportantTime2 datetime ,  --高级用户审核时间 干部其他重大事项 
	ResponsTime2	datetime,	--高级用户审核时间 干部违纪违规处理及追究 
	LetterTime2	datetime, 	--高级用户审核时间 干部信访核查 
	AdmTalkTime2	datetime, 	--高级用户审核时间 干部接受诫勉谈话 
	IncTalkTime2	datetime, 	--高级用户审核时间 干部接受廉政谈话 
	ApplyTime2	datetime, 	--高级用户审核时间 干部接受函询情况 
	

	UserInfoPeople1	nvarchar(50), 	--审核用户为审核人 _用户基本信息表
	FamilyPeople1	nvarchar(50), 	--家庭成员表 
	RewardPeople1	nvarchar(50), 	--审核用户为审核人 奖惩情况登记表
	RefusePeople1	nvarchar(50) ,	--审核用户为审核人 拒收或上交礼金 
	ProfitPeople1	nvarchar(50), 	--审核用户为审核人 参与营利及兼职持股 
	HousingPeople1	nvarchar(50), 	--审核用户为审核人 干部本人、配偶及共同生活的子女住房  
	MarryChgPeople1	nvarchar(50) ,	--审核用户为审核人 干部婚姻变化情况报告表
	WeddDiePeople1	nvarchar(50), 	--审核用户为审核人 干部操办本人及近亲婚丧喜庆事宜情况 
	AbroadPeople1	nvarchar(50), 	--审核用户为审核人 干部本人、配偶、子女及其配偶出国情况 
	CrimePeople1	nvarchar(50) ,	--审核用户为审核人 干审核用户审核 部配偶、子女涉嫌犯罪情况 
	IndustryPeople1	nvarchar(50), 	--审核用户为审核人 干部本人、配偶从业变更 
	ImportantPeople1 nvarchar(50) ,  --审核用户为审核人 干部其他重大事项 
	ResponsPeople1	nvarchar(50),	--审核用户为审核人 干部违纪违规处理及追究 
	LetterPeople1	nvarchar(50), 	--审核用户为审核人 干部信访核查 
	AdmTalkPeople1	nvarchar(50), 	--审核用户为审核人 干部接受诫勉谈话 
	IncTalkPeople1	nvarchar(50), 	--审核用户为审核人 干部接受廉政谈话 
	ApplyPeople1	nvarchar(50), 	--审核用户为审核人 干部接受函询情况 
	
	UserInfoPeople2	nvarchar(50), 	--高级用户为审核人 _用户基本信息表
	FamilyPeople2	nvarchar(50), 	--家庭成员表
	RewardPeople2	nvarchar(50), 	--高级用户为审核人 奖惩情况登记表
	RefusePeople2	nvarchar(50) ,	--高级用户为审核人 拒收或上交礼金 
	ProfitPeople2	nvarchar(50), 	--高级用户为审核人 参与营利及兼职持股 
	HousingPeople2	nvarchar(50), 	--高级用户为审核人 干部本人、配偶及共同生活的子女住房  
	MarryChgPeople2	nvarchar(50) ,	--高级用户为审核人 干部婚姻变化情况报告表
	WeddDiePeople2	nvarchar(50), 	--高级用户为审核人 干部操办本人及近亲婚丧喜庆事宜情况 
	AbroadPeople2	nvarchar(50), 	--高级用户为审核人 干部本人、配偶、子女及其配偶出国情况 
	CrimePeople2	nvarchar(50) ,	--高级用户为审核人 干审核用户审核 部配偶、子女涉嫌犯罪情况 
	IndustryPeople2	nvarchar(50), 	--高级用户为审核人 干部本人、配偶从业变更 
	ImportantPeople2 nvarchar(50) ,  --高级用户为审核人 干部其他重大事项 
	ResponsPeople2	nvarchar(50),	--高级用户为审核人 干部违纪违规处理及追究 
	LetterPeople2	nvarchar(50), 	--高级用户为审核人 干部信访核查 
	AdmTalkPeople2	nvarchar(50), 	--高级用户为审核人 干部接受诫勉谈话 
	IncTalkPeople2	nvarchar(50), 	--高级用户为审核人 干部接受廉政谈话 
	ApplyPeople2	nvarchar(50), 	--高级用户为审核人 干部接受函询情况 
	
	UserInfoStatus1	int, 	--审核用户审核状态 _用户基本信息表（1：通过、0：不通过）   
	FamilyStatus1	int, 	--家庭成员表 
	RewardStatus1	int, 	--审核用户审核状态 奖惩情况登记表
	RefuseStatus1	int ,	--审核用户审核状态 拒收或上交礼金 
	ProfitStatus1	int, 	--审核用户审核状态 参与营利及兼职持股 
	HousingStatus1	int, 	--审核用户审核状态 干部本人、配偶及共同生活的子女住房  
	MarryChgStatus1	int ,	--审核用户审核状态 干部婚姻变化情况报告表
	WeddDieStatus1	int, 	--审核用户审核状态 干部操办本人及近亲婚丧喜庆事宜情况 
	AbroadStatus1	int, 	--审核用户审核状态 干部本人、配偶、子女及其配偶出国情况 
	CrimeStatus1	int ,	--审核用户审核状态 审核用户审核 干部配偶、子女涉嫌犯罪情况 
	IndustryStatus1 int, 	--审核用户审核状态 干部本人、配偶从业变更 
	ImportantStatus1 int ,  --审核用户审核状态 干部其他重大事项 
	ResponsStatus1	int,	--审核用户审核状态 干部违纪违规处理及追究 
	LetterStatus1	int, 	--审核用户审核状态 干部信访核查 
	AdmTalkStatus1	int, 	--审核用户审核状态 干部接受诫勉谈话 
	IncTalkStatus1	int, 	--审核用户审核状态 干部接受廉政谈话 
	ApplyStatus1	int, 	--审核用户审核状态 干部接受函询情况 
	
	UserInfoStatus2	int, 	--高级用户审核状态 _用户基本信息表
	FamilyStatus2	int, 	--家庭成员表 
	RewardStatus2	int, 	--高级用户审核状态 奖惩情况登记表
	RefuseStatus2	int ,	--高级用户审核状态 拒收或上交礼金 
	ProfitStatus2	int, 	--高级用户审核状态 参与营利及兼职持股 
	HousingStatus2	int, 	--高级用户审核状态 干部本人、配偶及共同生活的子女住房  
	MarryChgStatus2	int ,	--高级用户审核状态 干部婚姻变化情况报告表
	WeddDieStatus2	int, 	--高级用户审核状态 干部操办本人及近亲婚丧喜庆事宜情况 
	AbroadStatus2	int, 	--高级用户审核状态 干部本人、配偶、子女及其配偶出国情况 
	CrimeStatus2	int ,	--高级用户审核状态 干审核用户审核 部配偶、子女涉嫌犯罪情况 
	IndustryStatus2 int, 	--高级用户审核状态 干部本人、配偶从业变更 
	ImportantStatus2 int ,  --高级用户审核状态 干部其他重大事项 
	ResponsStatus2	int,	--高级用户审核状态 干部违纪违规处理及追究 
	LetterStatus2	int, 	--高级用户审核状态 干部信访核查 
	AdmTalkStatus2	int, 	--高级用户审核状态 干部接受诫勉谈话 
	IncTalkStatus2	int, 	--高级用户审核状态 干部接受廉政谈话 
	ApplyStatus2	int, 	--高级用户审核状态 干部接受函询情况 
	
	Remark	nvarchar(100),	--备注	
)
select * from DT_Total


----------------所有登记表  总表16张 

--表一:科级干部基本情况登记表之基本信息（DT_UserInfo）		
if exists(select 1 from sys.objects where name='DT_UserInfo')
begin
	drop table DT_UserInfo
end
create table DT_UserInfo
(		
	Id	int primary key identity, 	--id
	UserId	int,  	--用户登录id
	
	YearTable int, --年份	
	Photo	nvarchar(200),	--照片
	RealName	nvarchar(50),	--真实姓名
	Sex	nvarchar(20),	--性别
	NativePlace	nvarchar(255),	--籍贯
	Birthday	datetime,	--出生日期
	IdCardNum	nvarchar(50),	--身份证号码
	Outlook 	nvarchar(50),	--政治面貌
	PartyTime	datetime,	--入党时间
	Nation	nvarchar(50),	--民族
	Property	nvarchar(50),	--本人编制性质
	JobTime	datetime,	--参加工作时间
	Education	nvarchar(50),	--最高学历
	WorkUnit  nvarchar(50),	--工作单位
	Post	nvarchar(50),	--现任职务
	PostStatus	nvarchar(50),	--职级（单位所在级别）
	PostTime	datetime,	--任现职务时间
	DoWork	nvarchar(50),	--分管工作
	UserAddress  	nvarchar(255),	--家庭住址
	Introduction	text,	--个人简历
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--更新时间
	Remark	nvarchar(255)	--备注
)
select * from  DT_UserInfo


-- 家庭成员分表（DT_Family）		
if exists(select 1 from sys.objects where name='DT_Family')
begin
	drop table DT_Family
end
create table DT_Family
(	
	Id	int primary key identity,	--id
	UserId	int,  	--用户登录id
	YearTable int, --年份
	Name	nvarchar(50),	--姓名
	Relation	nvarchar(50),	--称谓（关系）
	Outlook 	nvarchar(50),	--政治面貌
	WorkUnit	nvarchar(100),	--工作单位
	Post	nvarchar(50),	--职务		 
	FamilyTotalId int --家庭成员总表id
)
select * from DT_Family


-- 家庭成员总表（DT_FamilyTotal）		
if exists(select 1 from sys.objects where name='DT_FamilyTotal') 
begin
	drop table DT_FamilyTotal
end
create table DT_FamilyTotal
(	
	Id	int primary key identity,--id	 
	UserId	int,  	--用户登录id
	YearTable int, --年份	
	other	text,	--其他情况
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--更新时间 
)

select * from DT_FamilyTotal
select * from DT_Family


--表二:奖惩情况登记表（DT_RewardPunishTotal）	总表
 if exists(select 1 from sys.objects where name='DT_RewardPunishTotal')
begin
	drop table DT_RewardPunishTotal
end
create table DT_RewardPunishTotal
(	
	Id	int primary key identity,	--id
	UserId	int,  	--用户登录id
	YearTable int, --年份
	CheckAdvice	nvarchar(255),	--单位审核意见（PS:来自单位）
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--更新时间
	Remark	nvarchar(255)	--备注
)
 
--奖惩情况登记表之获奖（DT_Reward）	 分表1	

 if exists(select 1 from sys.objects where name='DT_Reward')
begin
	drop table DT_Reward
end
create table DT_Reward
(	
	Id	int primary key identity,	--id
	UserId	int,  	--用户登录id
	YearTable int, --年份
	RewardsTime	nvarchar(50),	--获奖时间
	RewardsDptandName	nvarchar(60),	--奖励机关及获奖名称	 
	Remark	nvarchar(255),	--备注 
	RewardTotalId	int  	--获奖总表id
 )
select * from DT_Reward
 
 
--奖惩情况登记表之受罚（DT_Punish） 	分表2
if exists(select 1 from sys.objects where name='DT_Punish')
begin
	drop table DT_Punish
end
create table DT_Punish
(
	Id	int primary key identity,	--id
	UserId	int,  	--用户登录id
	YearTable int, --年份
	PunishTime	nvarchar(50),	--受惩时间
	PunishName	nvarchar(50),	--所受处分
	PunishReason	nvarchar(255),	--受处分原因
	PunishDpt	nvarchar(50),	--惩处机关
	Remark	nvarchar(255),	--备注
	RewardTotalId	int  	--获奖总表id
)
select * from DT_Reward
select * from DT_Punish

--表三：拒收或上交礼金登记表（DT_RefuseGiftTotal）	总表	
if exists(select 1 from sys.objects where name='DT_RefuseGiftTotal')
begin
	drop table DT_RefuseGiftTotal
end
create table DT_RefuseGiftTotal
(
	Id	int primary key identity,	--用户登录id
	UserId	int,  	--用户登录id
	YearTable int, --年份
	CheckAdvice	nvarchar(255),	--单位审核意见（PS:来自单位）
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间	
	Remark	nvarchar(255)	--备注
)
select * from DT_RefuseGiftTotal

--拒收或上交礼金登记分表（DT_RefuseGift）	分表	
if exists(select 1 from sys.objects where name='DT_RefuseGift')
begin
	drop table DT_RefuseGift
end
create table DT_RefuseGift
(
	Id	int primary key identity,	--id	
	UserId	int,  	--用户登录id
	YearTable int, --年份	
	HandInMoney	nvarchar(80),	--上交金额
	HandInName	nvarchar(50),	--上交礼品名称
	HandInCount	int,	--上交数量
	HandInTime	nvarchar(50),	--上交时间
	HandInDpt	nvarchar(50),	--上交部门
	Remark	nvarchar(255),	--备注
	RefuseTotalId	int	--总表id

)
select * from DT_RefuseGift

--表四:参与营利及兼职持股情况报告表（DT_ProfitReport）	就一张表
if exists(select 1 from sys.objects where name='DT_ProfitReport')
begin
	drop table DT_ProfitReport
end
create table DT_ProfitReport
(
	Id	int primary key identity,	--id
	UserId	int	,--用户登录id
	YearTable int, --年份	
	CompanyName	nvarchar(50),	--企业名称
	BusinessScope	nvarchar(100),	--经营范围
	RegisterMoney	nvarchar(80),	--注册资金
	InvestmentRate	nvarchar(80),	--本人出资比例（百分比）
	YearProfit	nvarchar(80),	--年利润（元）
	ParttimeUnit	nvarchar(50),	--兼职单位
	ParttimeUnitNature	nvarchar(50),	--兼职单位性质
	ParttimePost	nvarchar(50),	--兼任职务
	YearMoney	nvarchar(80),	--年取酬
	InvestUnit	nvarchar(50),	--投资或入股单位
	InvestUnitNature	nvarchar(50),	--投资或入股单位性质
	InvestWay	nvarchar(50),	--投资或入股方式（资金入股、技术入股、其他入股）
	InvestMoney	nvarchar(80),	--投资或入股金额（元）
	YearIncome	nvarchar(80),	--年收益（元）
	Other	nvarchar(255),	--从事或参与其他证券投资情况
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
 
)
select * from DT_ProfitReport


--表五:干部本人、配偶及共同生活的子女住房情况报告表（DT_HousingTotal）	总表	
if exists(select 1 from sys.objects where name='DT_HousingTotal')
begin
	drop table DT_HousingTotal
end
create table DT_HousingTotal
(
	Id	int primary key identity,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份
	PartnerName	nvarchar(50),	--配偶姓名
	PartnerUnit	nvarchar(50),	--配偶单位
	PartnerPost	nvarchar(50),	--配偶职务
	Other	Nvarchar(100),	--其他说明情况（具体看表文档）
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
	Remark	nvarchar(255)	--备注
)
--insert into PartnerName DT_HousingTotal() values()
select * from DT_HousingTotal


--干部本人、配偶及共同生活的子女住房情况报告表之住房（DT_HousingHouse） 分表1
if exists(select 1 from sys.objects where name='DT_HousingHouse')
begin
	drop table DT_HousingHouse
end
create table DT_HousingHouse
(
	Id	int primary key identity,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份
	HouseAddress	nvarchar(100),	--现有住房地址（具体到街道、幢、室）
	Area	nvarchar(80),	--建筑面积
	HouseNature	nvarchar(50),	--房屋性质（说明里有多个）
	HouseFrom	nvarchar(50),	--房屋来源（说明里有多个）
	PropertyOwner	nvarchar(50),	--产权人
	HousingTotalId int --住房总表id
)


--干部本人、配偶及共同生活的子女住房情况报告表之购房（DT_HousingBuy）	分表2
if exists(select 1 from sys.objects where name='DT_HousingBuy')
begin
	drop table DT_HousingBuy
end
create table DT_HousingBuy
(
	Id	int primary key identity,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份
	BuyHouseAddress	nvarchar(100),	--购房地址
	BuyHouseArea	nvarchar(80),	--购房面积
	BuyHouseMoney	nvarchar(80),	--购房金额
	BuyHouseIncome	nvarchar(50),	--购房资金来源
	BuyHouseTime	datetime,	--购房时间
	HousingTotalId int --住房总表id
)
select * from dt_HousingBuy



--干部本人、配偶及共同生活的子女住房情况报告表之售房（DT_HousingSell） 分表3		
if exists(select 1 from sys.objects where name='DT_HousingSell')
begin
	drop table DT_HousingSell
end
create table DT_HousingSell
(
	Id	int primary key identity,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份
	SellHouseAddress	nvarchar(100),	--售房地址
	SellHouseArea	nvarchar(80),	--售房面积
	SellHouseNature	nvarchar(50),	--售房性质
	SellHouseTime	datetime,	--售房时间
	SellHouseMoney	nvarchar(80),	--售房金额
	HousingTotalId int --住房总表id
)
select * from DT_HousingSell


--干部本人、配偶及共同生活的子女住房情况报告表之出租（DT_HousingRentout） 分表4			
if exists(select 1 from sys.objects where name='DT_HousingRentout')
begin
	drop table DT_HousingRentout
end
create table DT_HousingRentout
(	 
	Id	int primary key identity,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份
	RentoutAddress	nvarchar(100),	--出租地址
	RentoutArea	nvarchar(80),	--出租房面积
	RentoutNature	nvarchar(50),	--出租房性质
	RentoutTime	datetime,	--租赁期限
	RentoutMoney	nvarchar(80),	--年租金（元）
	HousingTotalId int --住房总表id
)
select * from DT_HousingRentout



--干部本人、配偶及共同生活的子女住房情况报告表（DT_HousingBuild）之建房	分表5		
if exists(select 1 from sys.objects where name='DT_HousingBuild')
begin
	drop table DT_HousingBuild
end
create table DT_HousingBuild
(	
	Id	int primary key identity,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份
	BuildHousesAddress	nvarchar(100),	--集资建房地址
	BuildHousesArea	nvarchar(80),	--集资建房面积
	BuildHousesUnit	nvarchar(50),	--集资单位
	BuildHousesTotal	nvarchar(80),	--房款总额(元)
	Payment	nvarchar(80),	--个人支付（元）
	HousingTotalId int --住房总表id
)
select * from DT_HousingBuild


--表六:干部婚姻变化情况报告表（DT_MarryChange）   就一张表				
if exists(select 1 from sys.objects where name='DT_MarryChange')
begin
	drop table DT_MarryChange
end
create table DT_MarryChange
(
	Id	int primary key identity ,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份	
	IsMarryChange	nvarchar(5),	--是否有婚姻变化（true false）
	LastPartner	nvarchar(50),	--原配偶
	LastRegisterTime	datetime,	--现配偶婚姻登记时间
	LastEndTime	datetime,	--婚姻结束时间
	NowPartner	nvarchar(50),	--现配偶
	NowPolitical	nvarchar(50),	--现配偶政治面貌
	NowUnit	nvarchar(50),	--现配偶单位
	NowPost	nvarchar(50),	--现配偶职务
	NowRegisterTime	datetime,	--现配偶登记时间
	Other	nvarchar(255),	--其他情况
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
)
select * from DT_MarryChange

--表七: 干部操办本人及近亲婚丧喜庆事宜情况报告表（DT_WeddingandDie）	就一张表						
if exists(select 1 from sys.objects where name='DT_WeddingandDie')
begin
	drop table DT_WeddingandDie
end
create table DT_WeddingandDie
(
	Id int primary key identity ,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份	
	Arrange	nvarchar(200),	--操办事项
	ManageTime	nvarchar(50),	--办理时间
	ManageAddress	nvarchar(50),	--办理地点
	PartyObject	nvarchar(50),	--参加对象
	PartyNum	nvarchar(50)	,--参加人数
	AcceptingMoney	nvarchar(80),	--收受礼金金额（元）
	AcceptingCount	nvarchar(50),	--收受礼品数量（件）
	AcceptingValue	nvarchar(80),	--收受礼品价值（元）
	HandleStatus	nvarchar(200),	--所受礼金处理情况
	Adivce	nvarchar(200),	--组织意见（PS:来自组织）
	AdivceTime	datetime,	--组织意见时间
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
 
)

select * from DT_WeddingandDie


--表八:干部本人、配偶、子女及其配偶出国情况报告表（DT_GoAbroadTotal）总表
if exists(select 1 from sys.objects where name='DT_GoAbroadTotal')
begin
	drop table DT_GoAbroadTotal
end
create table DT_GoAbroadTotal
(
	Id	int primary key identity,	--id
	UserId	int,  	--用户登录id
	YearTable int, --年份
	LandingPaper	nvarchar(100),	--本人持出国证件
	HKCertificate	nvarchar(100),	--本人持港澳台证件
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
	MarryName	nvarchar(50),	--通婚子女姓名
	MarryUnit	nvarchar(100),	--通婚子女单位
	RegisterTime	nvarchar(50),	--婚姻登记时间
	MarryPartner	nvarchar(50),	--通婚配偶姓名
	PartnerNational	nvarchar(50),	--通婚配偶国籍
	Remark	nvarchar(255),	--备注
	
)
select * from DT_GoAbroadTotal


--干部本人、配偶、子女及其配偶出国情况报告表之办企业（DT_GoAbroadCompany）	分表1	
if exists(select 1 from sys.objects where name='DT_GoAbroadCompany')
begin
	drop table DT_GoAbroadCompany
end
create table DT_GoAbroadCompany
(	 
	Id	int primary key identity,	--id
	UserId	int,  	--用户登录id
	YearTable int, --年份
	BuildCompanyName	nvarchar(50),	--国外办企业配偶、子女姓名
	BuildCompanyTitle	nvarchar(50),	--国外办企业配偶、子女称谓
	BuildCompanyAddress	nvarchar(100),	--国外办企业配偶、子女地点
	CompanyName	nvarchar(50),	--国外办企业名称
	AbroadTotalId int --出国总表Id
)
select * from DT_GoAbroadCompany


--干部本人、配偶、子女及其配偶出国情况报告表之留学（DT_GoAbroadStudy）	分表2	
if exists(select 1 from sys.objects where name='DT_GoAbroadStudy')
begin
	drop table DT_GoAbroadStudy
end
create table DT_GoAbroadStudy
(	 	 
	Id	int primary key identity,	--id
	UserId	int,  	--用户登录id
	YearTable int, --年份
	StudyName	nvarchar(50),	--留学人姓名
	StudyTitle	nvarchar(50),	--留学人称谓
	StudyTime	nvarchar(50),	--留学时间
	StudyAddress	nvarchar(100),	--留学地点
	StudyMoney	nvarchar(80),	--留学费用（每年）
	AbroadTotalId int --出国总表Id
)


--干部本人、配偶、子女及其配偶出国情况报告表之定居	（DT_GoAbroadSettler）	分表3
if exists(select 1 from sys.objects where name='DT_GoAbroadSettler')
begin
	drop table DT_GoAbroadSettler
end
create table DT_GoAbroadSettler
(	
	Id	int primary key identity, 	--id
	UserId	int,  	--用户登录id
	YearTable int, --年份
	Settler	nvarchar(50),	--定居人姓名
	SettlerTitle	nvarchar(50),	--定居人称谓
	SettleTime	nvarchar(50),	--定居时间
	SettleAddress	nvarchar(100),	--定居地点
	SettlerWork	nvarchar(50),	--定居人从业
	AbroadTotalId int --出国总表Id	
)

--表九：干部配偶、子女涉嫌犯罪情况报告表（DT_CrimeReport）							
if exists(select 1 from sys.objects where name='DT_CrimeReport')
begin
	drop table DT_CrimeReport
end
create table DT_CrimeReport
(
	Id	int primary key identity ,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份	
	CrimerName	nvarchar(50),	--犯罪人姓名
	Relation	nvarchar(50),	--与犯罪人关系
	CrimerUnit	nvarchar(100),	--犯罪人单位
	CrimerPost	nvarchar(50),	--犯罪人职务
	LawAgency	nvarchar(50),	--执法机关
	Result	nvarchar(100),	--处理结果
	Remark	nvarchar(100),	--备注
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
)
select * from DT_CrimeReport


--表十：干部本人、配偶从业变更情况报告表（DT_IndustryChanges）								
if exists(select 1 from sys.objects where name='DT_IndustryChanges')
begin
	drop table DT_IndustryChanges
end
create table DT_IndustryChanges
(
	Id	int primary key identity ,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份	
	Name	nvarchar(50),	--从业变更人员
	Relation	nvarchar(50),	--与填表人关系
	ChangeTime	nvarchar(50),	--从业变更时间
	LastUnit	nvarchar(100),	--原单位
	LastPost	nvarchar(50),	--原职务
	NowUnit	nvarchar(100),	--现单位
	NowPost	nvarchar(50),	--现职务
	Reason	nvarchar(100),	--变更原因
	Remark	nvarchar(100),	--备注
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
 
)
select * from DT_IndustryChanges


--表十一：干部其他重大事项报告表（DT_Important）									
if exists(select 1 from sys.objects where name='DT_Important')
begin
	drop table DT_Important
end
create table DT_Important
(
	Id	int primary key identity ,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份	
	Report	nvarchar(255),	--报告事项
	CheckIn	nvarchar(100),	--领导审阅答复
	CheckInTime	datetime,	--审阅答复时间
	Remark	nvarchar(255),	--备注
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
	 
)
select * from DT_Important


--表十二：干部违纪违规处理及追究报告表（DT_Responsibility）											
if exists(select 1 from sys.objects where name='DT_Responsibility')
begin
	drop table DT_Responsibility
end
create table DT_Responsibility
(
	Id	int primary key identity ,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份	
	Nature	nvarchar(50),	--违纪性质
	ResTime	nvarchar(50),	--违纪时间
	HandleOffice	nvarchar(50),	--处理机关
	Fact	nvarchar(100),	--违纪事实
	HandleStatus	nvarchar(255),	--处理情况
	Remark	nvarchar(100),	--备注
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
	 
)
select * from DT_Responsibility


--表十三：干部信访核查情况表（DT_PetitionLetter）											
if exists(select 1 from sys.objects where name='DT_PetitionLetter')
begin
	drop table DT_PetitionLetter
end
create table DT_PetitionLetter
(
	Id	int primary key identity ,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份	
	RecordNum	nvarchar(50),	--信访登记号
	LetterTime	nvarchar(50),	--信访时间
	FromUnit	nvarchar(50),	--信息来源单位
	ByManName	nvarchar(50),	--被反映人姓名
	ByManPost	nvarchar(50),	--被反映人职务
	ByManUnit	nvarchar(50),	--被反映人单位
	ManName	nvarchar(50),	--反映人姓名
	ManTel	nvarchar(50),	--反映人联系方式
	ManUnit	nvarchar(50),	--反映人单位
	ManPost	nvarchar(50),	--反映人职务
	Content	nvarchar(255),	--信访反映内容
	SurveyResult	nvarchar(255),	--调查结论
	HandleResult	nvarchar(255),	--处理结果
	Remark	nvarchar(255),	--备注
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
	 
)
select * from DT_PetitionLetter


--表十四：干部接受诫勉谈话情况登记表（DT_AdmonishingTalk）												
if exists(select 1 from sys.objects where name='DT_AdmonishingTalk')
begin
	drop table DT_AdmonishingTalk
end
create table DT_AdmonishingTalk
(
	Id	int primary key identity,	--id
	UserId	int,	--用户登录id(被谈话人)
	YearTable int, --年份	
	BeLordTalk	nvarchar(50),	--被谈话人姓名
	BePost	nvarchar(50),	--被谈话人职务
	BeUnit	nvarchar(50),--被谈话人工作单位
	TalkReason	nvarchar(255),	--谈话原因
	LordTalk	nvarchar(50),	--谈话人姓名
	Post	nvarchar(50),	--谈话人职务
	TalkTime	nvarchar(50),	--谈话时间
	TalkAddress  	nvarchar(50),	--谈话地点
	Content	nvarchar(255),	--谈话内容
	ObjectAdvice	nvarchar(100),	--谈话对象意见
	LordTalkAdvice	nvarchar(100),	--谈话人意见
	Remark	nvarchar(100),	--备注
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
	 
)
select * from DT_AdmonishingTalk


--表十五：干部接受廉政谈话情况登记表（DT_IncorruptTalk）												
if exists(select 1 from sys.objects where name='DT_IncorruptTalk')
begin
	drop table DT_IncorruptTalk
end
create table DT_IncorruptTalk
(
	Id	int primary key identity ,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份	
	TalkReason	nvarchar(255),	--谈话原因
	TalkTime	nvarchar(50),	--谈话时间
	TalkAddress  	nvarchar(50),	--谈话地点
	LordTalk	nvarchar(50),	--主谈人
	RecordPerson	nvarchar(50),	--记录人
	Content	nvarchar(255),	--谈话内容
	Remark	nvarchar(100),	--备注
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
	 
)
select * from DT_IncorruptTalk



--表十六：干部接受函询情况登记表（DT_ApplyByLetter）														
if exists(select 1 from sys.objects where name='DT_ApplyByLetter')
begin
	drop table DT_ApplyByLetter
end
create table DT_ApplyByLetter
(
	Id	int primary key identity,	--id
	UserId	int,	--用户登录id
	YearTable int, --年份	
	ApplyTime	nvarchar(50),	--函询时间
	Reason	nvarchar(255),	--函询事由
	Answer	nvarchar(255),	--函询回复情况
	Remark	nvarchar(100),	--备注
	FillTime	datetime,	--填表时间
	UpdateTime	datetime,	--修改时间
	 
)
select * from DT_ApplyByLetter

