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
    
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AttributeDeNorm> AttributeDeNorms { get; set; }
    
        public virtual ObjectResult<UspGetAttribute_Result> UspGetAttribute(string gridCode)
        {
            var gridCodeParameter = gridCode != null ?
                new ObjectParameter("GridCode", gridCode) :
                new ObjectParameter("GridCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UspGetAttribute_Result>("UspGetAttribute", gridCodeParameter);
        }
    
        public virtual ObjectResult<UspInsAttribute_Result> UspInsAttribute(string gridCode, string rowCode, string colCode, string attrib, string value, string expand)
        {
            var gridCodeParameter = gridCode != null ?
                new ObjectParameter("GridCode", gridCode) :
                new ObjectParameter("GridCode", typeof(string));
    
            var rowCodeParameter = rowCode != null ?
                new ObjectParameter("RowCode", rowCode) :
                new ObjectParameter("RowCode", typeof(string));
    
            var colCodeParameter = colCode != null ?
                new ObjectParameter("ColCode", colCode) :
                new ObjectParameter("ColCode", typeof(string));
    
            var attribParameter = attrib != null ?
                new ObjectParameter("Attrib", attrib) :
                new ObjectParameter("Attrib", typeof(string));
    
            var valueParameter = value != null ?
                new ObjectParameter("Value", value) :
                new ObjectParameter("Value", typeof(string));
    
            var expandParameter = expand != null ?
                new ObjectParameter("Expand", expand) :
                new ObjectParameter("Expand", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UspInsAttribute_Result>("UspInsAttribute", gridCodeParameter, rowCodeParameter, colCodeParameter, attribParameter, valueParameter, expandParameter);
        }
    }
}