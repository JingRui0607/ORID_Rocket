declare @Startday date

select top(1) @Startday =  startDate from  Student where  (id = @Sid) 


declare @Endday date
select top(1) @Endday = endDate from Student where  (id = @Sid) 

declare @totalWeek int
select   @totalWeek = DATEDIFF(WEEK,@Startday,@Endday)+1;


--計算第幾週
declare @weekday date
select @weekday = case when DATEPART(weekday , @chooseDay)=1 then DATEADD(day,-1,@chooseDay) else @chooseDay end 

SELECT     DATEDIFF(WEEK,@Startday, @weekday)+1 as week

into #week2




declare @week int
select @week = week from #week2



SELECT    Student.name,  ORID_data.週一目標 AS target , DATEDIFF(WEEK,@Startday,填寫時間)+1 as week

into #week3
FROM            ORID_data INNER JOIN
                         Student ON ORID_data.Sid = Student.id
					 

where (ORID_data.Sid = @Sid) and DATEPART(weekday , 填寫時間)=2





SELECT    #week3.week as week ,isnull(#week3.target,0) as target
into #final
FROM     #week3 RIGHT OUTER JOIN
              week ON #week3.week = week.week


			  where week.week <=@totalWeek

 

select target from  #final where week=@week