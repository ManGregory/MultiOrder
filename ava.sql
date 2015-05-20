select a.Id, a.Name, a.ClassroomId, 
	(case
		when a.OrderedAmount is Null then a.Amount
		else a.Amount - a.OrderedAmount 
	end) as Amount
from
	(select e.Id, e.Name, e.ClassroomId, e.Amount,
		(select sum(oe.Amount)
		from OrdersEquipments oe 
			join Orders o on oe.OrderId = o.Id and o.IsSigned = 1 and cast(o.[Date] as Date) = '2015-05-21' and 1 between o.FromPair and o.ToPair
		where oe.EquipmentId = e.Id) as OrderedAmount
	from Equipments e) a

select sum(oe.Amount)
from OrdersEquipments oe 
	join Orders o on oe.OrderId = o.Id and o.IsSigned = 1 and o.Date = '2015-05-21' and 1 between o.FromPair and o.ToPair
where oe.EquipmentId = 2

select * from Orders o where cast(o.[Date] as Date) = '2015-05-21'
	
