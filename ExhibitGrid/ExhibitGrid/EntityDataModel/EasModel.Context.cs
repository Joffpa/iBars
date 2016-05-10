﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExhibitGrid.EntityDataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DEV_AF : DbContext
    {
        public DEV_AF()
            : base("name=DEV_AF")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LOAD_PARAMETERS> LOAD_PARAMETERS { get; set; }
        public virtual DbSet<Widget> Widgets { get; set; }
        public virtual DbSet<WidgetSelection> WidgetSelections { get; set; }
        public virtual DbSet<WidgetType> WidgetTypes { get; set; }
        public virtual DbSet<WidgetContext> WidgetContexts { get; set; }
        public virtual DbSet<WidgetSelectionWidget> WidgetSelectionWidgets { get; set; }
    
        public virtual ObjectResult<Attributes> UspGetAttribVal(string gridCode)
        {
            var gridCodeParameter = gridCode != null ?
                new ObjectParameter("GridCode", gridCode) :
                new ObjectParameter("GridCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Attributes>("UspGetAttribVal", gridCodeParameter);
        }
    
        public virtual ObjectResult<UspGetRowRelationship_Result> UspGetRowRelationship(string parGridCode, string chGridCode)
        {
            var parGridCodeParameter = parGridCode != null ?
                new ObjectParameter("ParGridCode", parGridCode) :
                new ObjectParameter("ParGridCode", typeof(string));
    
            var chGridCodeParameter = chGridCode != null ?
                new ObjectParameter("ChGridCode", chGridCode) :
                new ObjectParameter("ChGridCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UspGetRowRelationship_Result>("UspGetRowRelationship", parGridCodeParameter, chGridCodeParameter);
        }
    
        public virtual ObjectResult<UspGetCalcs_Result> UspGetCalcs(string gridCode)
        {
            var gridCodeParameter = gridCode != null ?
                new ObjectParameter("GridCode", gridCode) :
                new ObjectParameter("GridCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UspGetCalcs_Result>("UspGetCalcs", gridCodeParameter);
        }
    }
}
