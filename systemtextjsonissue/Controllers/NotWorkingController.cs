using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace systemtextjsonissue.Controllers {

	[ApiController]
	[Route("[controller]")]
	public class NotWorkingController : ControllerBase {

		private readonly ILogger<NotWorkingController> _logger;

		public NotWorkingController(ILogger<NotWorkingController> logger) {
			_logger = logger;
		}

		[HttpGet]
		public SurveyReportResult Get() {
			return new SurveyReportResult {
				Id = Guid.NewGuid(),
				Name = "Root",
				MemberCount = 4,
				OrganisationalUnits = new OrganisationalUnit[] {
					new OrganisationalUnitWithParticipantGroups {
						Id = Guid.NewGuid(),
						Name = "Level 2",
						MemberCount = 4,
						ParticipantGroups = new ParticipantGroup[]{
							new ParticipantGroup {
								Id = Guid.NewGuid(),
								MemberCount = 4,
								Name = "end"
							}
						}
					}
				}
			};
		}


		public class SurveyReportResult {
			public Guid Id { get; set; }
			public String Name { get; set; }
			public Int32 MemberCount { get; set; }
			public IEnumerable<OrganisationalUnit> OrganisationalUnits { get; set; }
		}

		public abstract class OrganisationalUnit {
			public Guid Id { get; set; }
			public String Name { get; set; }
			public Int32 MemberCount { get; set; }

		}

		public class OrganisationalUnitWithParticipantGroups : OrganisationalUnit {
			public IEnumerable<ParticipantGroup> ParticipantGroups { get; set; }
		}

		public class ParticipantGroup {
			public Guid Id { get; set; }
			public String Name { get; set; }
			public Int32 MemberCount { get; set; }
		}

	}
}