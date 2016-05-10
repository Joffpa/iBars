

--select * from LOAD_PARAMETERS p
--join WidgetContext wc on p.parameter_id_pk = wc.ContextId
--join Widget w on wc.WidgetId = w.WidgetId
--where parm_block_fk = (SELECT TOP 1 parm_block_pk from def_parameter_block WHERE parm_block_desc = 'Exhibit Interface')
--order by parm_order

DECLARE @parmId int
SET  @parmId = (SELECT TOP 1 parameter_id_pk from LOAD_PARAMETERS WHERE parm_name = 'ShowNegativeInParensInUI')
delete from WidgetContext where ContextId = @parmId AND ContextType = 'PARM'
delete from LOAD_PARAMETERS where parameter_id_pk = @parmId

DECLARE @parmBlockId int, @parmOrder int, @widgetId int
SET  @parmBlockId = (SELECT TOP 1 parm_block_pk from def_parameter_block WHERE parm_block_desc = 'Exhibit Interface')
SET  @parmOrder = (SELECT max(parm_order) from LOAD_PARAMETERS WHERE parm_block_fk = @parmBlockId)
SET  @widgetId = (SELECT TOP 1 WidgetId from Widget WHERE Code = 'YesNoDropDown')

insert into LOAD_PARAMETERS(parm_name, parm_value, parm_label, parm_order, visible, parm_block_fk, HoverText)
values ('ShowNegativeInParensInUI', 'N', 'Show negative numbers in parenthesis in UI', @parmOrder + 1, 1, @parmBlockId, 'Determines if the UI will show negative numbers in parentheses.')
SET @parmId = @@IDENTITY

insert into WidgetContext (WidgetId,ContextId,ContextType)
VALUES (  @widgetId, @parmId, 'PARM')


update LOAD_PARAMETERS set parm_value = 'N' where parm_name = 'ShowNegativeInParensInUI'


