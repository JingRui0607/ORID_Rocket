--SELECT    (select name from Student where id = @name), replace(目標完成度,'%','') as reach 


--FROM            ORID_data INNER JOIN
--                         Student ON ORID_data.Sid = Student.id

--where (ORID_data.Sid = @name) and 填寫時間 between dateadd(week,@week,@Friday) and  dateadd(day,1,dateadd(week,@week,@Friday))




declare @Startday date

select top(1) @Startday =  startDate from  Student where  (id = @name) 


declare @Endday date
select top(1) @Endday = endDate from Student where  (id = @name) 

declare @totalWeek int
select   @totalWeek = DATEDIFF(WEEK,@Startday,@Endday)+1;




SELECT    Student.name as name, replace(目標完成度,'%','') as reach , DATEDIFF(WEEK,@Startday,填寫時間)+1 as week

into #week2
FROM            ORID_data INNER JOIN
                         Student ON ORID_data.Sid = Student.id
						 



where (ORID_data.Sid =  @name) and DATEPART(weekday , 填寫時間)=6


SELECT   isnull(#week2.reach,0) as reach
FROM     #week2 RIGHT OUTER JOIN
              week ON #week2.week = week.week

			  where week.week <=@totalWeek



