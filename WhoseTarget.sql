--SELECT    ISNULL( 週一目標,'忘記寫') as target from ORID_data where 姓名=@name and DATEPART(weekday,填寫時間)=2

--SELECT * FROM ORID_data WHERE 週一目標 IS NOT NULL  AND 姓名='京叡' AND 週一目標 != ''

--SELECT     週一目標 as target  from ORID_data where 姓名=@name and 填寫時間 between dateadd(week,@week,@monday) and  dateadd(day,1,dateadd(week,@week,@monday))


--SELECT        ORID_data.週一目標 AS target
--FROM            ORID_data INNER JOIN
--                         Student ON ORID_data.Sid = Student.id
--WHERE        (ORID_data.Sid = @Sid) and 填寫時間 between dateadd(week,@week,@monday) and  dateadd(day,1,dateadd(week,@week,@monday))


declare @Startday date

select top(1) @Startday =  startDate from  Student where  (id = @Sid) 


declare @Endday date
select top(1) @Endday = endDate from Student where  (id = @Sid) 

declare @totalWeek int
select   @totalWeek = DATEDIFF(WEEK,@Startday,@Endday)+1;



SELECT        ORID_data.週一目標 AS target,DATEDIFF(WEEK,@Startday,填寫時間)+1 as week

into #week2
FROM            ORID_data INNER JOIN
                         Student ON ORID_data.Sid = Student.id
WHERE        (ORID_data.Sid = @Sid) and  DATEPART(weekday , 填寫時間)=2

SELECT   week.week,isnull(#week2.target,'未填寫') as target
FROM     week LEFT OUTER JOIN
              #week2 ON week.week = #week2.week