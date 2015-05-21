--select a.Id, a.Name, a.ClassroomId, 
--	(case
--		when a.OrderedAmount is Null then a.Amount
--		else a.Amount - a.OrderedAmount 
--	end) as Amount
--from
--	(select e.Id, e.Name, e.ClassroomId, e.Amount,
--		(select max(oe.Amount)
--		from OrdersEquipments oe 
--			join Orders o on oe.OrderId = o.Id and o.IsSigned = 1 and cast(o.[Date] as Date) = '2015-05-21' and o.FromPair >= 1 and o.ToPair <= 5
--		where oe.EquipmentId = e.Id
--		group o.FromPair) as OrderedAmount
--	from Equipments e) a

--select sum(oe.Amount)
--from OrdersEquipments oe 
--	join Orders o on oe.OrderId = o.Id and o.IsSigned = 1 and o.Date = '2015-05-21' and 1 between o.FromPair and o.ToPair
--where oe.EquipmentId = 2

--select * from Orders o where cast(o.[Date] as Date) = '2015-05-21'




select a.Id, a.Name, a.ClassroomId, 
	(case
		when a.OrderedAmount is Null then a.Amount
		else a.Amount - a.OrderedAmount 
	 end) as Amount
from
	(select e.Id, e.Name, e.ClassroomId, e.Amount,
		(select max(b.am)
		from 
			(select sum(oe.Amount) am
			from OrdersEquipments oe 
				join Orders o on oe.OrderId = o.Id and o.IsSigned = 1 and cast(o.[Date] as Date) = '2015-05-25' and ((1 between o.FromPair and o.ToPair) or (1 between o.FromPair and o.ToPair))
			where oe.EquipmentId = e.Id) as b) as OrderedAmount
	from Equipments e) a
where a.ClassroomId is null

	
select * from OrdersEquipments oe 
	join Orders o on o.Id = oe.OrderId and cast(o.[Date] as Date) = '2015-05-25'

select sum(oe.Amount) am, cast(o.FromPair as VARCHAR) + '-' + cast(o.ToPair as VARCHAR)
from OrdersEquipments oe 
	join Orders o on oe.OrderId in (29, 45, 46) and o.IsSigned = 1 and cast(o.[Date] as Date) = '2015-05-25' and (o.FromPair >= 1 or o.ToPair <= 5) and o.Id = oe.OrderId
where oe.EquipmentId in (2)
group by cast(o.FromPair as VARCHAR) + '-' + cast(o.ToPair as VARCHAR)
