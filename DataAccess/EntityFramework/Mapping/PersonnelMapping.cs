using Hastane.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.EntityFramework.Mapping
{
	public class PersonnelMapping:BaseEntityTypeConfig<Personnel>
	{
		public override void Configure(EntityTypeBuilder<Personnel> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).IsRequired();
			base.Configure(builder);
		}
	}
}
