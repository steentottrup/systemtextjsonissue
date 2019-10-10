using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace systemtextjsonissue.Controllers {

	[ApiController]
	[Route("[controller]")]
	public class WorkingController : ControllerBase {

		private readonly ILogger<WorkingController> _logger;

		public WorkingController(ILogger<WorkingController> logger) {
			_logger = logger;
		}

		[HttpGet]
		public SurveyReportResult Get() {
			return new SurveyReportResult {
				Id = Guid.NewGuid(),
				Name = "Root",
				MemberCount = 4,
				OrganisationalUnits = new OrganisationalUnitWithParticipantGroups[] {
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
			public IEnumerable<OrganisationalUnitWithParticipantGroups> OrganisationalUnits { get; set; }
		}

		public class OrganisationalUnitWithParticipantGroups {
			public Guid Id { get; set; }
			public String Name { get; set; }
			public Int32 MemberCount { get; set; }
			public IEnumerable<ParticipantGroup> ParticipantGroups { get; set; }
		}

		public class ParticipantGroup {
			public Guid Id { get; set; }
			public String Name { get; set; }
			public Int32 MemberCount { get; set; }
		}

	}
}