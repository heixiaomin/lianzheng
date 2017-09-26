use master
go
------------NewDb  Ŀǰ�ܹ���35�ű�

if exists(select 1 from sys.databases where name='db_gblz')
begin
	drop database db_gblz
end
create database db_gblz
go
use db_gblz
go

----8�ű�

--�û���¼��¼��DT_UserLoginRecord��		
if exists(select 1 from sys.objects where name='DT_UserLoginRecord')
begin
	drop table DT_UserLoginRecord
end
create table DT_UserLoginRecord
(
	Id	int primary key identity,	--id
	Telphone 	nvarchar(20),	--�ֻ�����(�����û���)
	Password	nvarchar(50),	--����
	LoginTime	Datetime,	--��¼ʱ��
	LoginIp	Varchar(20),	--��¼IP
	LoginNum	int,	--��¼����
	Remark	Varchar(40),	--��ע
	RoleId	int,	--��ɫId
	IsInner 	bit,	--�Ƿ�ϵͳ�ڲ���Ա
	IsCadre	bit default 'false' ,	--�Ƿ�Ƽ��ɲ�
	WorkUnitId	int,	--��λ����id
	DeptId	int,	--����id
	Effectivedate	datetime,	--��Ч�ڣ������Ч�ڣ�
	Status	bit,	--�˺�״̬���˺��Ƿ���ã�
	RealName	nvarchar(50),	--��ʵ����
	WorkUnit	nvarchar(50),	--��λ����
	Department	nvarchar(50),	--��������
	Upost nvarchar(50),--ְ��
	FillStatus	nvarchar(50),	--���״̬
	ShareStatus	nvarchar(50),	--����״̬
	
	AddTime datetime,--���ʱ��
	UpdateTime datetime--�޸�ʱ��
)
--e10adc3949ba59abbe56e057f20f883e  YisaaAdmin.             E1ADC3949BA59ABBE56E057F2F883E
insert into DT_UserLoginRecord(Telphone,Password,RoleId,IsInner,IsCadre,Status,RealName) values('YisaaAdmin.','e10adc3949ba59abbe56e057f20f883e',4,'true','true','true','С��')
select * from DT_UserLoginRecord

select * from DT_Total
 
select * from DT_UserInfo

--������λ��(DT_WorkUnit) 		
if exists(select 1 from sys.objects where name='DT_WorkUnit')
begin
	drop table DT_WorkUnit 
end
create table DT_WorkUnit
( 
	Id	 int primary key identity,	--id
	UnitName	nvarchar(50),	--��λ����
	ParentId	int, 	--����id
	CreateUnit  	nvarchar(50),	--������λ����
	CreateDept  	nvarchar(50),	--�������ҵ���
	AddUnitTime 	datetime,	--��ӵ�λ��ʱ��
	AddDeptTime 	datetime,	--��ӿ��ҵ�ʱ��
	UpdUnitTime 	datetime,	--�޸ĵ�λ��ʱ�� 
	UpdDeptTime 	datetime,	--�޸Ŀ��ҵ�ʱ��	
	Remarks	nvarchar(255) 	--��ע
)
select * from DT_WorkUnit
	
--��λ/���ұ����(DT_DeptChange)		
if exists(select 1 from sys.objects where name='DT_UnitDeptChange')
begin
	drop table DT_UnitDeptChange
end
create table DT_UnitDeptChange
(
	Id	int	primary key identity, --id
	UserId	int,	--�û���¼id
	UnitName	nvarchar(50),	--ԭ������λ
	DeptName	nvarchar(50),	--ԭ����
	AddTime	datetime,	--���ʱ��
	Remarks	nvarchar(150)	--��ע

)

--��ɫ��DT_Role��		
if exists(select 1 from sys.objects where name='DT_Role')
begin
	drop table DT_Role
end
create table DT_Role
(
	Id	int primary key identity,	--id
	Name	nvarchar(50),	--��ɫ����
	Remark	nvarchar(100)	--��ע		
)
select * from DT_Role

	
	
--�����DT_Share��	
if exists(select 1 from sys.objects where name='DT_Share')
begin
	drop table DT_Share
end
create table DT_Share
(
	Id	int primary key identity, 	--id
	BeSharedPeople	nvarchar(50),	--�������ˣ��Ѿ��鵵�ĿƼ��ɲ���
	SharedYear	int,	--�������
	ShareBeginTime	datetime,	--����ʼʱ��
	ShareEndTime	datetime,	--�������ʱ��
	SharePeople	nvarchar(50),	--������(ϵͳ�ڡ�ϵͳ��)
	CreateTime 	datetime,	--����ʱ��	
	
	BeSharedId 	int,--��������id
	ShareId int --������id
	
)	
select * from DT_Share

select BeSharedId from DT_Share where ShareId=5

select * from DT_Share where ShareId=5
select * from DT_Share where ShareId=13
--���ݴ�������shareid��ѯ��BeShareId�ļ���
--���ݴ�������shareid��ѯ������һ����¼
	
--�������˱�DT_BeShared��	
if exists(select 1 from sys.objects where name='DT_BeShared')
begin
	drop table DT_BeShared
end
create table DT_BeShared
(
	Id	int primary key identity, 	--id
	BeSharedId	int	--�������ˣ��Ѿ��鵵�ĿƼ��ɲ���
)
select * from DT_BeShared

	
--�����˱�DT_SharePeople��	
if exists(select 1 from sys.objects where name='DT_SharePeople')
begin
	drop table DT_SharePeople
end
create table DT_SharePeople
(
	Id	int primary key identity, 	--id
	ShareId	int,	--������(ϵͳ�ڡ�ϵͳ��)
	TotalId int
)
select * from DT_SharePeople

	
--����ʱ���DT_BuildTime��	 
if exists(select 1 from sys.objects where name='DT_BuildTime')
begin
	drop table DT_BuildTime
end
create table DT_BuildTime
(		
	Id	int primary key identity, 	--id
	BuildStartTime	datetime,	--������ʼʱ��
	BuildEndTime	datetime,	--��������ʱ��
	AddTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
	Remark	nvarchar(100)	--��ע
)
select * from DT_BuildTime
--2	2017-06-22 00:00:00.000	2018-07-21 00:00:00.000	2017-06-22 16:09:01.867	2018-07-14 09:26:01.960	NULL
	
--�ܱ�DT_Total�����еĵǼǱ�	156�ֶ�		
if exists(select 1 from sys.objects where name='DT_Total')
begin
	drop table DT_Total
end
create table DT_Total
(	
	Id	int primary key identity,--id
	UserId	int,	--�û���¼id
	YearTable int, --���
	AddTime datetime,--���ʱ��
	UpdTime datetime,--�޸�ʱ��  
			
	Status nvarchar(15),   --״̬��δ�ύ�����ύ�����˻أ��ѹ鵵��
	CheckStatus nvarchar(15),  --���״̬��1����ˡ�2���˻ء�3���ύ��4���˻أ��ѹ鵵��
	FileStatus  nvarchar(15), --�鵵״̬�����鵵�����˻ء��ѹ鵵��
	
	BackTime datetime,--����û��˻�ʱ��
	ChkSubmitTime	datetime, --����û��ύ��ίʱ��
	HighBackTime datetime,--�߼��û��˻�ʱ��
	HighFileTime	datetime, --�߼��û��鵵ʱ��	

	UserInfoId	int, 	--�û�������Ϣ��
	FamilyId	int, 	--��ͥ��Ա��
	RewardId	int, 	--��������ǼǱ�
	RefuseGiftId	int ,	--���ջ��Ͻ����ǼǱ�
	ProfitId	int, 	--����Ӫ������ְ�ֹ���������
	HousingId	int, 	--�ɲ����ˡ���ż����ͬ�������Ůס����������
	MarryChangeId	int ,	--�ɲ������仯��������
	WeddingandDieId	int, 	--�ɲ��ٰ챾�˼����׻�ɥϲ��������������
	GoAbroadId	int, 	--�ɲ����ˡ���ż����Ů������ż������������
	CrimeId	int ,	--�ɲ���ż����Ů���ӷ�����������
	IndustryChangesId	int, 	--�ɲ����ˡ���ż��ҵ�����������
	ImportantId	int ,	--�ɲ������ش�������
	ResponsibilityId	int,	--�ɲ�Υ��Υ�洦��׷�������
	PetitionLetterId	int, 	--�ɲ��ŷú˲������
	AdmonishingTalkId	int, 	--�ɲ����ܽ���̸������ǼǱ�
	IncorruptTalkId	int, 	--�ɲ���������̸������ǼǱ�
	ApplyByLetterId	int, 	--�ɲ����ܺ�ѯ����ǼǱ�
	
	UserInfoAdvice1	nvarchar(100), 	--����û������� _�û�������Ϣ��
	FamilyAdvice1	nvarchar(100), 	--��ͥ��Ա�� 
	RewardAdvice1	nvarchar(100), 	--����û������� ��������ǼǱ�
	RefuseAdvice1	nvarchar(100),	--����û������� ���ջ��Ͻ���� 
	ProfitAdvice1	nvarchar(100), 	--����û������� ����Ӫ������ְ�ֹ� 
	HousingAdvice1	nvarchar(100), 	--����û������� �ɲ����ˡ���ż����ͬ�������Ůס��  
	MarryChgAdvice1	nvarchar(100) ,	--����û������� �ɲ������仯��������
	WeddDieAdvice1	nvarchar(100), 	--����û������� �ɲ��ٰ챾�˼����׻�ɥϲ��������� 
	AbroadAdvice1	nvarchar(100), 	--����û������� �ɲ����ˡ���ż����Ů������ż������� 
	CrimeAdvice1	nvarchar(100) ,	--����û������� ������û���� ����ż����Ů���ӷ������ 
	IndustryAdvice1	nvarchar(100), 	--����û������� �ɲ����ˡ���ż��ҵ��� 
	ImportantAdvice1 nvarchar(100) ,  --����û�������� �ɲ������ش����� 
	ResponsAdvice1	nvarchar(100),	--����û������� �ɲ�Υ��Υ�洦��׷�� 
	LetterAdvice1	nvarchar(100), 	--����û������� �ɲ��ŷú˲� 
	AdmTalkAdvice1	nvarchar(100), 	--����û������� �ɲ����ܽ���̸�� 
	IncTalkAdvice1	nvarchar(100), 	--����û������� �ɲ���������̸�� 
	ApplyAdvice1	nvarchar(100), 	--����û������� �ɲ����ܺ�ѯ��� 
	
	UserInfoAdvice2	nvarchar(100), 	--�߼��û������� _�û�������Ϣ��
	FamilyAdvice2	nvarchar(100), 	--��ͥ��Ա�� 
	RewardAdvice2	nvarchar(100), 	--�߼��û������� ��������ǼǱ� 
	RefuseAdvice2	nvarchar(50),	--�߼��û������� ���ջ��Ͻ���� 
	ProfitAdvice2	nvarchar(100), 	--�߼��û������� ����Ӫ������ְ�ֹ� 
	HousingAdvice2	nvarchar(100), 	--�߼��û������� �ɲ����ˡ���ż����ͬ�������Ůס�� 
	MarryChgAdvice2	nvarchar(100) ,	--�߼��û������� �ɲ������仯 
	WeddDieAdvice2	nvarchar(100), 	--�߼��û������� �ɲ��ٰ챾�˼����׻�ɥϲ������ 
	AbroadAdvice2	nvarchar(100), 	--�߼��û������� �ɲ����ˡ���ż����Ů������ż���� 
	CrimeAdvice2	nvarchar(100) ,	--�߼��û������� ������û���� ����ż����Ů���ӷ��� 
	IndustryAdvice2	nvarchar(100), 	--�߼��û������� �ɲ����ˡ���ż��ҵ��� 
	ImportantAdvice2 nvarchar(100) ,  --�߼��û�������� �ɲ������ش����� 
	ResponsAdvice2	nvarchar(100),	--�߼��û������� �ɲ�Υ��Υ�洦��׷�� 
	LetterAdvice2	nvarchar(100), 	--�߼��û������� �ɲ��ŷú˲� 
	AdmTalkAdvice2	nvarchar(100), 	--�߼��û������� �ɲ����ܽ���̸�� 
	IncTalkAdvice2	nvarchar(100), 	--�߼��û������� �ɲ���������̸�� 
	ApplyAdvice2	nvarchar(100), 	--�߼��û������� �ɲ����ܺ�ѯ 
	
	UserInfoTime1	datetime, 	--����û����ʱ�� _�û�������Ϣ��
	FamilyTime1	datetime, 	--��ͥ��Ա�� 
	RewardTime1	datetime, 	--����û����ʱ�� ��������ǼǱ�
	RefuseTime1	datetime ,	--����û����ʱ�� ���ջ��Ͻ���� 
	ProfitTime1	datetime, 	--����û����ʱ�� ����Ӫ������ְ�ֹ� 
	HousingTime1	datetime, 	--����û����ʱ�� �ɲ����ˡ���ż����ͬ�������Ůס��  
	MarryChgTime1	datetime ,	--����û����ʱ�� �ɲ������仯��������
	WeddDieTime1	datetime, 	--����û����ʱ�� �ɲ��ٰ챾�˼����׻�ɥϲ��������� 
	AbroadTime1	datetime, 	--����û����ʱ�� �ɲ����ˡ���ż����Ů������ż������� 
	CrimeTime1	datetime ,	--����û����ʱ�� ������û���� ����ż����Ů���ӷ������ 
	IndustryTime1	datetime, 	--����û����ʱ�� �ɲ����ˡ���ż��ҵ��� 
	ImportantTime1 datetime ,  --����û����ʱ�� �ɲ������ش����� 
	ResponsTime1	datetime,	--����û����ʱ�� �ɲ�Υ��Υ�洦��׷�� 
	LetterTime1	datetime, 	--����û����ʱ�� �ɲ��ŷú˲� 
	AdmTalkTime1	datetime, 	--����û����ʱ�� �ɲ����ܽ���̸�� 
	IncTalkTime1	datetime, 	--����û����ʱ�� �ɲ���������̸�� 
	ApplyTime1	datetime, 	--����û����ʱ�� �ɲ����ܺ�ѯ��� 
	
	UserInfoTime2	datetime, 	--�߼��û����ʱ�� _�û�������Ϣ��
	FamilyTime2	datetime, 	--��ͥ��Ա�� 
	RewardTime2	datetime, 	--�߼��û����ʱ�� ��������ǼǱ�
	RefuseTime2	datetime ,	--�߼��û����ʱ�� ���ջ��Ͻ���� 
	ProfitTime2	datetime, 	--�߼��û����ʱ�� ����Ӫ������ְ�ֹ� 
	HousingTime2	datetime, 	--�߼��û����ʱ�� �ɲ����ˡ���ż����ͬ�������Ůס��  
	MarryChgTime2	datetime ,	--�߼��û����ʱ�� �ɲ������仯��������
	WeddDieTime2	datetime, 	--�߼��û����ʱ�� �ɲ��ٰ챾�˼����׻�ɥϲ��������� 
	AbroadTime2	datetime, 	--�߼��û����ʱ�� �ɲ����ˡ���ż����Ů������ż������� 
	CrimeTime2	datetime ,	--�߼��û����ʱ�� ������û���� ����ż����Ů���ӷ������ 
	IndustryTime2	datetime, 	--�߼��û����ʱ�� �ɲ����ˡ���ż��ҵ��� 
	ImportantTime2 datetime ,  --�߼��û����ʱ�� �ɲ������ش����� 
	ResponsTime2	datetime,	--�߼��û����ʱ�� �ɲ�Υ��Υ�洦��׷�� 
	LetterTime2	datetime, 	--�߼��û����ʱ�� �ɲ��ŷú˲� 
	AdmTalkTime2	datetime, 	--�߼��û����ʱ�� �ɲ����ܽ���̸�� 
	IncTalkTime2	datetime, 	--�߼��û����ʱ�� �ɲ���������̸�� 
	ApplyTime2	datetime, 	--�߼��û����ʱ�� �ɲ����ܺ�ѯ��� 
	

	UserInfoPeople1	nvarchar(50), 	--����û�Ϊ����� _�û�������Ϣ��
	FamilyPeople1	nvarchar(50), 	--��ͥ��Ա�� 
	RewardPeople1	nvarchar(50), 	--����û�Ϊ����� ��������ǼǱ�
	RefusePeople1	nvarchar(50) ,	--����û�Ϊ����� ���ջ��Ͻ���� 
	ProfitPeople1	nvarchar(50), 	--����û�Ϊ����� ����Ӫ������ְ�ֹ� 
	HousingPeople1	nvarchar(50), 	--����û�Ϊ����� �ɲ����ˡ���ż����ͬ�������Ůס��  
	MarryChgPeople1	nvarchar(50) ,	--����û�Ϊ����� �ɲ������仯��������
	WeddDiePeople1	nvarchar(50), 	--����û�Ϊ����� �ɲ��ٰ챾�˼����׻�ɥϲ��������� 
	AbroadPeople1	nvarchar(50), 	--����û�Ϊ����� �ɲ����ˡ���ż����Ů������ż������� 
	CrimePeople1	nvarchar(50) ,	--����û�Ϊ����� ������û���� ����ż����Ů���ӷ������ 
	IndustryPeople1	nvarchar(50), 	--����û�Ϊ����� �ɲ����ˡ���ż��ҵ��� 
	ImportantPeople1 nvarchar(50) ,  --����û�Ϊ����� �ɲ������ش����� 
	ResponsPeople1	nvarchar(50),	--����û�Ϊ����� �ɲ�Υ��Υ�洦��׷�� 
	LetterPeople1	nvarchar(50), 	--����û�Ϊ����� �ɲ��ŷú˲� 
	AdmTalkPeople1	nvarchar(50), 	--����û�Ϊ����� �ɲ����ܽ���̸�� 
	IncTalkPeople1	nvarchar(50), 	--����û�Ϊ����� �ɲ���������̸�� 
	ApplyPeople1	nvarchar(50), 	--����û�Ϊ����� �ɲ����ܺ�ѯ��� 
	
	UserInfoPeople2	nvarchar(50), 	--�߼��û�Ϊ����� _�û�������Ϣ��
	FamilyPeople2	nvarchar(50), 	--��ͥ��Ա��
	RewardPeople2	nvarchar(50), 	--�߼��û�Ϊ����� ��������ǼǱ�
	RefusePeople2	nvarchar(50) ,	--�߼��û�Ϊ����� ���ջ��Ͻ���� 
	ProfitPeople2	nvarchar(50), 	--�߼��û�Ϊ����� ����Ӫ������ְ�ֹ� 
	HousingPeople2	nvarchar(50), 	--�߼��û�Ϊ����� �ɲ����ˡ���ż����ͬ�������Ůס��  
	MarryChgPeople2	nvarchar(50) ,	--�߼��û�Ϊ����� �ɲ������仯��������
	WeddDiePeople2	nvarchar(50), 	--�߼��û�Ϊ����� �ɲ��ٰ챾�˼����׻�ɥϲ��������� 
	AbroadPeople2	nvarchar(50), 	--�߼��û�Ϊ����� �ɲ����ˡ���ż����Ů������ż������� 
	CrimePeople2	nvarchar(50) ,	--�߼��û�Ϊ����� ������û���� ����ż����Ů���ӷ������ 
	IndustryPeople2	nvarchar(50), 	--�߼��û�Ϊ����� �ɲ����ˡ���ż��ҵ��� 
	ImportantPeople2 nvarchar(50) ,  --�߼��û�Ϊ����� �ɲ������ش����� 
	ResponsPeople2	nvarchar(50),	--�߼��û�Ϊ����� �ɲ�Υ��Υ�洦��׷�� 
	LetterPeople2	nvarchar(50), 	--�߼��û�Ϊ����� �ɲ��ŷú˲� 
	AdmTalkPeople2	nvarchar(50), 	--�߼��û�Ϊ����� �ɲ����ܽ���̸�� 
	IncTalkPeople2	nvarchar(50), 	--�߼��û�Ϊ����� �ɲ���������̸�� 
	ApplyPeople2	nvarchar(50), 	--�߼��û�Ϊ����� �ɲ����ܺ�ѯ��� 
	
	UserInfoStatus1	int, 	--����û����״̬ _�û�������Ϣ��1��ͨ����0����ͨ����   
	FamilyStatus1	int, 	--��ͥ��Ա�� 
	RewardStatus1	int, 	--����û����״̬ ��������ǼǱ�
	RefuseStatus1	int ,	--����û����״̬ ���ջ��Ͻ���� 
	ProfitStatus1	int, 	--����û����״̬ ����Ӫ������ְ�ֹ� 
	HousingStatus1	int, 	--����û����״̬ �ɲ����ˡ���ż����ͬ�������Ůס��  
	MarryChgStatus1	int ,	--����û����״̬ �ɲ������仯��������
	WeddDieStatus1	int, 	--����û����״̬ �ɲ��ٰ챾�˼����׻�ɥϲ��������� 
	AbroadStatus1	int, 	--����û����״̬ �ɲ����ˡ���ż����Ů������ż������� 
	CrimeStatus1	int ,	--����û����״̬ ����û���� �ɲ���ż����Ů���ӷ������ 
	IndustryStatus1 int, 	--����û����״̬ �ɲ����ˡ���ż��ҵ��� 
	ImportantStatus1 int ,  --����û����״̬ �ɲ������ش����� 
	ResponsStatus1	int,	--����û����״̬ �ɲ�Υ��Υ�洦��׷�� 
	LetterStatus1	int, 	--����û����״̬ �ɲ��ŷú˲� 
	AdmTalkStatus1	int, 	--����û����״̬ �ɲ����ܽ���̸�� 
	IncTalkStatus1	int, 	--����û����״̬ �ɲ���������̸�� 
	ApplyStatus1	int, 	--����û����״̬ �ɲ����ܺ�ѯ��� 
	
	UserInfoStatus2	int, 	--�߼��û����״̬ _�û�������Ϣ��
	FamilyStatus2	int, 	--��ͥ��Ա�� 
	RewardStatus2	int, 	--�߼��û����״̬ ��������ǼǱ�
	RefuseStatus2	int ,	--�߼��û����״̬ ���ջ��Ͻ���� 
	ProfitStatus2	int, 	--�߼��û����״̬ ����Ӫ������ְ�ֹ� 
	HousingStatus2	int, 	--�߼��û����״̬ �ɲ����ˡ���ż����ͬ�������Ůס��  
	MarryChgStatus2	int ,	--�߼��û����״̬ �ɲ������仯��������
	WeddDieStatus2	int, 	--�߼��û����״̬ �ɲ��ٰ챾�˼����׻�ɥϲ��������� 
	AbroadStatus2	int, 	--�߼��û����״̬ �ɲ����ˡ���ż����Ů������ż������� 
	CrimeStatus2	int ,	--�߼��û����״̬ ������û���� ����ż����Ů���ӷ������ 
	IndustryStatus2 int, 	--�߼��û����״̬ �ɲ����ˡ���ż��ҵ��� 
	ImportantStatus2 int ,  --�߼��û����״̬ �ɲ������ش����� 
	ResponsStatus2	int,	--�߼��û����״̬ �ɲ�Υ��Υ�洦��׷�� 
	LetterStatus2	int, 	--�߼��û����״̬ �ɲ��ŷú˲� 
	AdmTalkStatus2	int, 	--�߼��û����״̬ �ɲ����ܽ���̸�� 
	IncTalkStatus2	int, 	--�߼��û����״̬ �ɲ���������̸�� 
	ApplyStatus2	int, 	--�߼��û����״̬ �ɲ����ܺ�ѯ��� 
	
	Remark	nvarchar(100),	--��ע	
)
select * from DT_Total


----------------���еǼǱ�  �ܱ�16�� 

--��һ:�Ƽ��ɲ���������ǼǱ�֮������Ϣ��DT_UserInfo��		
if exists(select 1 from sys.objects where name='DT_UserInfo')
begin
	drop table DT_UserInfo
end
create table DT_UserInfo
(		
	Id	int primary key identity, 	--id
	UserId	int,  	--�û���¼id
	
	YearTable int, --���	
	Photo	nvarchar(200),	--��Ƭ
	RealName	nvarchar(50),	--��ʵ����
	Sex	nvarchar(20),	--�Ա�
	NativePlace	nvarchar(255),	--����
	Birthday	datetime,	--��������
	IdCardNum	nvarchar(50),	--���֤����
	Outlook 	nvarchar(50),	--������ò
	PartyTime	datetime,	--�뵳ʱ��
	Nation	nvarchar(50),	--����
	Property	nvarchar(50),	--���˱�������
	JobTime	datetime,	--�μӹ���ʱ��
	Education	nvarchar(50),	--���ѧ��
	WorkUnit  nvarchar(50),	--������λ
	Post	nvarchar(50),	--����ְ��
	PostStatus	nvarchar(50),	--ְ������λ���ڼ���
	PostTime	datetime,	--����ְ��ʱ��
	DoWork	nvarchar(50),	--�ֹܹ���
	UserAddress  	nvarchar(255),	--��ͥסַ
	Introduction	text,	--���˼���
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--����ʱ��
	Remark	nvarchar(255)	--��ע
)
select * from  DT_UserInfo


-- ��ͥ��Ա�ֱ�DT_Family��		
if exists(select 1 from sys.objects where name='DT_Family')
begin
	drop table DT_Family
end
create table DT_Family
(	
	Id	int primary key identity,	--id
	UserId	int,  	--�û���¼id
	YearTable int, --���
	Name	nvarchar(50),	--����
	Relation	nvarchar(50),	--��ν����ϵ��
	Outlook 	nvarchar(50),	--������ò
	WorkUnit	nvarchar(100),	--������λ
	Post	nvarchar(50),	--ְ��		 
	FamilyTotalId int --��ͥ��Ա�ܱ�id
)
select * from DT_Family


-- ��ͥ��Ա�ܱ�DT_FamilyTotal��		
if exists(select 1 from sys.objects where name='DT_FamilyTotal') 
begin
	drop table DT_FamilyTotal
end
create table DT_FamilyTotal
(	
	Id	int primary key identity,--id	 
	UserId	int,  	--�û���¼id
	YearTable int, --���	
	other	text,	--�������
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--����ʱ�� 
)

select * from DT_FamilyTotal
select * from DT_Family


--���:��������ǼǱ�DT_RewardPunishTotal��	�ܱ�
 if exists(select 1 from sys.objects where name='DT_RewardPunishTotal')
begin
	drop table DT_RewardPunishTotal
end
create table DT_RewardPunishTotal
(	
	Id	int primary key identity,	--id
	UserId	int,  	--�û���¼id
	YearTable int, --���
	CheckAdvice	nvarchar(255),	--��λ��������PS:���Ե�λ��
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--����ʱ��
	Remark	nvarchar(255)	--��ע
)
 
--��������ǼǱ�֮�񽱣�DT_Reward��	 �ֱ�1	

 if exists(select 1 from sys.objects where name='DT_Reward')
begin
	drop table DT_Reward
end
create table DT_Reward
(	
	Id	int primary key identity,	--id
	UserId	int,  	--�û���¼id
	YearTable int, --���
	RewardsTime	nvarchar(50),	--��ʱ��
	RewardsDptandName	nvarchar(60),	--�������ؼ�������	 
	Remark	nvarchar(255),	--��ע 
	RewardTotalId	int  	--���ܱ�id
 )
select * from DT_Reward
 
 
--��������ǼǱ�֮�ܷ���DT_Punish�� 	�ֱ�2
if exists(select 1 from sys.objects where name='DT_Punish')
begin
	drop table DT_Punish
end
create table DT_Punish
(
	Id	int primary key identity,	--id
	UserId	int,  	--�û���¼id
	YearTable int, --���
	PunishTime	nvarchar(50),	--�ܳ�ʱ��
	PunishName	nvarchar(50),	--���ܴ���
	PunishReason	nvarchar(255),	--�ܴ���ԭ��
	PunishDpt	nvarchar(50),	--�ʹ�����
	Remark	nvarchar(255),	--��ע
	RewardTotalId	int  	--���ܱ�id
)
select * from DT_Reward
select * from DT_Punish

--���������ջ��Ͻ����ǼǱ�DT_RefuseGiftTotal��	�ܱ�	
if exists(select 1 from sys.objects where name='DT_RefuseGiftTotal')
begin
	drop table DT_RefuseGiftTotal
end
create table DT_RefuseGiftTotal
(
	Id	int primary key identity,	--�û���¼id
	UserId	int,  	--�û���¼id
	YearTable int, --���
	CheckAdvice	nvarchar(255),	--��λ��������PS:���Ե�λ��
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��	
	Remark	nvarchar(255)	--��ע
)
select * from DT_RefuseGiftTotal

--���ջ��Ͻ����ǼǷֱ�DT_RefuseGift��	�ֱ�	
if exists(select 1 from sys.objects where name='DT_RefuseGift')
begin
	drop table DT_RefuseGift
end
create table DT_RefuseGift
(
	Id	int primary key identity,	--id	
	UserId	int,  	--�û���¼id
	YearTable int, --���	
	HandInMoney	nvarchar(80),	--�Ͻ����
	HandInName	nvarchar(50),	--�Ͻ���Ʒ����
	HandInCount	int,	--�Ͻ�����
	HandInTime	nvarchar(50),	--�Ͻ�ʱ��
	HandInDpt	nvarchar(50),	--�Ͻ�����
	Remark	nvarchar(255),	--��ע
	RefuseTotalId	int	--�ܱ�id

)
select * from DT_RefuseGift

--����:����Ӫ������ְ�ֹ���������DT_ProfitReport��	��һ�ű�
if exists(select 1 from sys.objects where name='DT_ProfitReport')
begin
	drop table DT_ProfitReport
end
create table DT_ProfitReport
(
	Id	int primary key identity,	--id
	UserId	int	,--�û���¼id
	YearTable int, --���	
	CompanyName	nvarchar(50),	--��ҵ����
	BusinessScope	nvarchar(100),	--��Ӫ��Χ
	RegisterMoney	nvarchar(80),	--ע���ʽ�
	InvestmentRate	nvarchar(80),	--���˳��ʱ������ٷֱȣ�
	YearProfit	nvarchar(80),	--������Ԫ��
	ParttimeUnit	nvarchar(50),	--��ְ��λ
	ParttimeUnitNature	nvarchar(50),	--��ְ��λ����
	ParttimePost	nvarchar(50),	--����ְ��
	YearMoney	nvarchar(80),	--��ȡ��
	InvestUnit	nvarchar(50),	--Ͷ�ʻ���ɵ�λ
	InvestUnitNature	nvarchar(50),	--Ͷ�ʻ���ɵ�λ����
	InvestWay	nvarchar(50),	--Ͷ�ʻ���ɷ�ʽ���ʽ���ɡ�������ɡ�������ɣ�
	InvestMoney	nvarchar(80),	--Ͷ�ʻ���ɽ�Ԫ��
	YearIncome	nvarchar(80),	--�����棨Ԫ��
	Other	nvarchar(255),	--���»��������֤ȯͶ�����
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
 
)
select * from DT_ProfitReport


--����:�ɲ����ˡ���ż����ͬ�������Ůס����������DT_HousingTotal��	�ܱ�	
if exists(select 1 from sys.objects where name='DT_HousingTotal')
begin
	drop table DT_HousingTotal
end
create table DT_HousingTotal
(
	Id	int primary key identity,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���
	PartnerName	nvarchar(50),	--��ż����
	PartnerUnit	nvarchar(50),	--��ż��λ
	PartnerPost	nvarchar(50),	--��żְ��
	Other	Nvarchar(100),	--����˵����������忴���ĵ���
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
	Remark	nvarchar(255)	--��ע
)
--insert into PartnerName DT_HousingTotal() values()
select * from DT_HousingTotal


--�ɲ����ˡ���ż����ͬ�������Ůס����������֮ס����DT_HousingHouse�� �ֱ�1
if exists(select 1 from sys.objects where name='DT_HousingHouse')
begin
	drop table DT_HousingHouse
end
create table DT_HousingHouse
(
	Id	int primary key identity,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���
	HouseAddress	nvarchar(100),	--����ס����ַ�����嵽�ֵ��������ң�
	Area	nvarchar(80),	--�������
	HouseNature	nvarchar(50),	--�������ʣ�˵�����ж����
	HouseFrom	nvarchar(50),	--������Դ��˵�����ж����
	PropertyOwner	nvarchar(50),	--��Ȩ��
	HousingTotalId int --ס���ܱ�id
)


--�ɲ����ˡ���ż����ͬ�������Ůס����������֮������DT_HousingBuy��	�ֱ�2
if exists(select 1 from sys.objects where name='DT_HousingBuy')
begin
	drop table DT_HousingBuy
end
create table DT_HousingBuy
(
	Id	int primary key identity,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���
	BuyHouseAddress	nvarchar(100),	--������ַ
	BuyHouseArea	nvarchar(80),	--�������
	BuyHouseMoney	nvarchar(80),	--�������
	BuyHouseIncome	nvarchar(50),	--�����ʽ���Դ
	BuyHouseTime	datetime,	--����ʱ��
	HousingTotalId int --ס���ܱ�id
)
select * from dt_HousingBuy



--�ɲ����ˡ���ż����ͬ�������Ůס����������֮�۷���DT_HousingSell�� �ֱ�3		
if exists(select 1 from sys.objects where name='DT_HousingSell')
begin
	drop table DT_HousingSell
end
create table DT_HousingSell
(
	Id	int primary key identity,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���
	SellHouseAddress	nvarchar(100),	--�۷���ַ
	SellHouseArea	nvarchar(80),	--�۷����
	SellHouseNature	nvarchar(50),	--�۷�����
	SellHouseTime	datetime,	--�۷�ʱ��
	SellHouseMoney	nvarchar(80),	--�۷����
	HousingTotalId int --ס���ܱ�id
)
select * from DT_HousingSell


--�ɲ����ˡ���ż����ͬ�������Ůס����������֮���⣨DT_HousingRentout�� �ֱ�4			
if exists(select 1 from sys.objects where name='DT_HousingRentout')
begin
	drop table DT_HousingRentout
end
create table DT_HousingRentout
(	 
	Id	int primary key identity,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���
	RentoutAddress	nvarchar(100),	--�����ַ
	RentoutArea	nvarchar(80),	--���ⷿ���
	RentoutNature	nvarchar(50),	--���ⷿ����
	RentoutTime	datetime,	--��������
	RentoutMoney	nvarchar(80),	--�����Ԫ��
	HousingTotalId int --ס���ܱ�id
)
select * from DT_HousingRentout



--�ɲ����ˡ���ż����ͬ�������Ůס����������DT_HousingBuild��֮����	�ֱ�5		
if exists(select 1 from sys.objects where name='DT_HousingBuild')
begin
	drop table DT_HousingBuild
end
create table DT_HousingBuild
(	
	Id	int primary key identity,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���
	BuildHousesAddress	nvarchar(100),	--���ʽ�����ַ
	BuildHousesArea	nvarchar(80),	--���ʽ������
	BuildHousesUnit	nvarchar(50),	--���ʵ�λ
	BuildHousesTotal	nvarchar(80),	--�����ܶ�(Ԫ)
	Payment	nvarchar(80),	--����֧����Ԫ��
	HousingTotalId int --ס���ܱ�id
)
select * from DT_HousingBuild


--����:�ɲ������仯��������DT_MarryChange��   ��һ�ű�				
if exists(select 1 from sys.objects where name='DT_MarryChange')
begin
	drop table DT_MarryChange
end
create table DT_MarryChange
(
	Id	int primary key identity ,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���	
	IsMarryChange	nvarchar(5),	--�Ƿ��л����仯��true false��
	LastPartner	nvarchar(50),	--ԭ��ż
	LastRegisterTime	datetime,	--����ż�����Ǽ�ʱ��
	LastEndTime	datetime,	--��������ʱ��
	NowPartner	nvarchar(50),	--����ż
	NowPolitical	nvarchar(50),	--����ż������ò
	NowUnit	nvarchar(50),	--����ż��λ
	NowPost	nvarchar(50),	--����żְ��
	NowRegisterTime	datetime,	--����ż�Ǽ�ʱ��
	Other	nvarchar(255),	--�������
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
)
select * from DT_MarryChange

--����: �ɲ��ٰ챾�˼����׻�ɥϲ��������������DT_WeddingandDie��	��һ�ű�						
if exists(select 1 from sys.objects where name='DT_WeddingandDie')
begin
	drop table DT_WeddingandDie
end
create table DT_WeddingandDie
(
	Id int primary key identity ,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���	
	Arrange	nvarchar(200),	--�ٰ�����
	ManageTime	nvarchar(50),	--����ʱ��
	ManageAddress	nvarchar(50),	--����ص�
	PartyObject	nvarchar(50),	--�μӶ���
	PartyNum	nvarchar(50)	,--�μ�����
	AcceptingMoney	nvarchar(80),	--��������Ԫ��
	AcceptingCount	nvarchar(50),	--������Ʒ����������
	AcceptingValue	nvarchar(80),	--������Ʒ��ֵ��Ԫ��
	HandleStatus	nvarchar(200),	--������������
	Adivce	nvarchar(200),	--��֯�����PS:������֯��
	AdivceTime	datetime,	--��֯���ʱ��
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
 
)

select * from DT_WeddingandDie


--���:�ɲ����ˡ���ż����Ů������ż������������DT_GoAbroadTotal���ܱ�
if exists(select 1 from sys.objects where name='DT_GoAbroadTotal')
begin
	drop table DT_GoAbroadTotal
end
create table DT_GoAbroadTotal
(
	Id	int primary key identity,	--id
	UserId	int,  	--�û���¼id
	YearTable int, --���
	LandingPaper	nvarchar(100),	--���˳ֳ���֤��
	HKCertificate	nvarchar(100),	--���˳ָ۰�̨֤��
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
	MarryName	nvarchar(50),	--ͨ����Ů����
	MarryUnit	nvarchar(100),	--ͨ����Ů��λ
	RegisterTime	nvarchar(50),	--�����Ǽ�ʱ��
	MarryPartner	nvarchar(50),	--ͨ����ż����
	PartnerNational	nvarchar(50),	--ͨ����ż����
	Remark	nvarchar(255),	--��ע
	
)
select * from DT_GoAbroadTotal


--�ɲ����ˡ���ż����Ů������ż������������֮����ҵ��DT_GoAbroadCompany��	�ֱ�1	
if exists(select 1 from sys.objects where name='DT_GoAbroadCompany')
begin
	drop table DT_GoAbroadCompany
end
create table DT_GoAbroadCompany
(	 
	Id	int primary key identity,	--id
	UserId	int,  	--�û���¼id
	YearTable int, --���
	BuildCompanyName	nvarchar(50),	--�������ҵ��ż����Ů����
	BuildCompanyTitle	nvarchar(50),	--�������ҵ��ż����Ů��ν
	BuildCompanyAddress	nvarchar(100),	--�������ҵ��ż����Ů�ص�
	CompanyName	nvarchar(50),	--�������ҵ����
	AbroadTotalId int --�����ܱ�Id
)
select * from DT_GoAbroadCompany


--�ɲ����ˡ���ż����Ů������ż������������֮��ѧ��DT_GoAbroadStudy��	�ֱ�2	
if exists(select 1 from sys.objects where name='DT_GoAbroadStudy')
begin
	drop table DT_GoAbroadStudy
end
create table DT_GoAbroadStudy
(	 	 
	Id	int primary key identity,	--id
	UserId	int,  	--�û���¼id
	YearTable int, --���
	StudyName	nvarchar(50),	--��ѧ������
	StudyTitle	nvarchar(50),	--��ѧ�˳�ν
	StudyTime	nvarchar(50),	--��ѧʱ��
	StudyAddress	nvarchar(100),	--��ѧ�ص�
	StudyMoney	nvarchar(80),	--��ѧ���ã�ÿ�꣩
	AbroadTotalId int --�����ܱ�Id
)


--�ɲ����ˡ���ż����Ů������ż������������֮����	��DT_GoAbroadSettler��	�ֱ�3
if exists(select 1 from sys.objects where name='DT_GoAbroadSettler')
begin
	drop table DT_GoAbroadSettler
end
create table DT_GoAbroadSettler
(	
	Id	int primary key identity, 	--id
	UserId	int,  	--�û���¼id
	YearTable int, --���
	Settler	nvarchar(50),	--����������
	SettlerTitle	nvarchar(50),	--�����˳�ν
	SettleTime	nvarchar(50),	--����ʱ��
	SettleAddress	nvarchar(100),	--���ӵص�
	SettlerWork	nvarchar(50),	--�����˴�ҵ
	AbroadTotalId int --�����ܱ�Id	
)

--��ţ��ɲ���ż����Ů���ӷ�����������DT_CrimeReport��							
if exists(select 1 from sys.objects where name='DT_CrimeReport')
begin
	drop table DT_CrimeReport
end
create table DT_CrimeReport
(
	Id	int primary key identity ,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���	
	CrimerName	nvarchar(50),	--����������
	Relation	nvarchar(50),	--�뷸���˹�ϵ
	CrimerUnit	nvarchar(100),	--�����˵�λ
	CrimerPost	nvarchar(50),	--������ְ��
	LawAgency	nvarchar(50),	--ִ������
	Result	nvarchar(100),	--������
	Remark	nvarchar(100),	--��ע
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
)
select * from DT_CrimeReport


--��ʮ���ɲ����ˡ���ż��ҵ�����������DT_IndustryChanges��								
if exists(select 1 from sys.objects where name='DT_IndustryChanges')
begin
	drop table DT_IndustryChanges
end
create table DT_IndustryChanges
(
	Id	int primary key identity ,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���	
	Name	nvarchar(50),	--��ҵ�����Ա
	Relation	nvarchar(50),	--������˹�ϵ
	ChangeTime	nvarchar(50),	--��ҵ���ʱ��
	LastUnit	nvarchar(100),	--ԭ��λ
	LastPost	nvarchar(50),	--ԭְ��
	NowUnit	nvarchar(100),	--�ֵ�λ
	NowPost	nvarchar(50),	--��ְ��
	Reason	nvarchar(100),	--���ԭ��
	Remark	nvarchar(100),	--��ע
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
 
)
select * from DT_IndustryChanges


--��ʮһ���ɲ������ش�������DT_Important��									
if exists(select 1 from sys.objects where name='DT_Important')
begin
	drop table DT_Important
end
create table DT_Important
(
	Id	int primary key identity ,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���	
	Report	nvarchar(255),	--��������
	CheckIn	nvarchar(100),	--�쵼���Ĵ�
	CheckInTime	datetime,	--���Ĵ�ʱ��
	Remark	nvarchar(255),	--��ע
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
	 
)
select * from DT_Important


--��ʮ�����ɲ�Υ��Υ�洦��׷�������DT_Responsibility��											
if exists(select 1 from sys.objects where name='DT_Responsibility')
begin
	drop table DT_Responsibility
end
create table DT_Responsibility
(
	Id	int primary key identity ,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���	
	Nature	nvarchar(50),	--Υ������
	ResTime	nvarchar(50),	--Υ��ʱ��
	HandleOffice	nvarchar(50),	--�������
	Fact	nvarchar(100),	--Υ����ʵ
	HandleStatus	nvarchar(255),	--�������
	Remark	nvarchar(100),	--��ע
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
	 
)
select * from DT_Responsibility


--��ʮ�����ɲ��ŷú˲������DT_PetitionLetter��											
if exists(select 1 from sys.objects where name='DT_PetitionLetter')
begin
	drop table DT_PetitionLetter
end
create table DT_PetitionLetter
(
	Id	int primary key identity ,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���	
	RecordNum	nvarchar(50),	--�ŷõǼǺ�
	LetterTime	nvarchar(50),	--�ŷ�ʱ��
	FromUnit	nvarchar(50),	--��Ϣ��Դ��λ
	ByManName	nvarchar(50),	--����ӳ������
	ByManPost	nvarchar(50),	--����ӳ��ְ��
	ByManUnit	nvarchar(50),	--����ӳ�˵�λ
	ManName	nvarchar(50),	--��ӳ������
	ManTel	nvarchar(50),	--��ӳ����ϵ��ʽ
	ManUnit	nvarchar(50),	--��ӳ�˵�λ
	ManPost	nvarchar(50),	--��ӳ��ְ��
	Content	nvarchar(255),	--�ŷ÷�ӳ����
	SurveyResult	nvarchar(255),	--�������
	HandleResult	nvarchar(255),	--������
	Remark	nvarchar(255),	--��ע
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
	 
)
select * from DT_PetitionLetter


--��ʮ�ģ��ɲ����ܽ���̸������ǼǱ�DT_AdmonishingTalk��												
if exists(select 1 from sys.objects where name='DT_AdmonishingTalk')
begin
	drop table DT_AdmonishingTalk
end
create table DT_AdmonishingTalk
(
	Id	int primary key identity,	--id
	UserId	int,	--�û���¼id(��̸����)
	YearTable int, --���	
	BeLordTalk	nvarchar(50),	--��̸��������
	BePost	nvarchar(50),	--��̸����ְ��
	BeUnit	nvarchar(50),--��̸���˹�����λ
	TalkReason	nvarchar(255),	--̸��ԭ��
	LordTalk	nvarchar(50),	--̸��������
	Post	nvarchar(50),	--̸����ְ��
	TalkTime	nvarchar(50),	--̸��ʱ��
	TalkAddress  	nvarchar(50),	--̸���ص�
	Content	nvarchar(255),	--̸������
	ObjectAdvice	nvarchar(100),	--̸���������
	LordTalkAdvice	nvarchar(100),	--̸�������
	Remark	nvarchar(100),	--��ע
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
	 
)
select * from DT_AdmonishingTalk


--��ʮ�壺�ɲ���������̸������ǼǱ�DT_IncorruptTalk��												
if exists(select 1 from sys.objects where name='DT_IncorruptTalk')
begin
	drop table DT_IncorruptTalk
end
create table DT_IncorruptTalk
(
	Id	int primary key identity ,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���	
	TalkReason	nvarchar(255),	--̸��ԭ��
	TalkTime	nvarchar(50),	--̸��ʱ��
	TalkAddress  	nvarchar(50),	--̸���ص�
	LordTalk	nvarchar(50),	--��̸��
	RecordPerson	nvarchar(50),	--��¼��
	Content	nvarchar(255),	--̸������
	Remark	nvarchar(100),	--��ע
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
	 
)
select * from DT_IncorruptTalk



--��ʮ�����ɲ����ܺ�ѯ����ǼǱ�DT_ApplyByLetter��														
if exists(select 1 from sys.objects where name='DT_ApplyByLetter')
begin
	drop table DT_ApplyByLetter
end
create table DT_ApplyByLetter
(
	Id	int primary key identity,	--id
	UserId	int,	--�û���¼id
	YearTable int, --���	
	ApplyTime	nvarchar(50),	--��ѯʱ��
	Reason	nvarchar(255),	--��ѯ����
	Answer	nvarchar(255),	--��ѯ�ظ����
	Remark	nvarchar(100),	--��ע
	FillTime	datetime,	--���ʱ��
	UpdateTime	datetime,	--�޸�ʱ��
	 
)
select * from DT_ApplyByLetter

