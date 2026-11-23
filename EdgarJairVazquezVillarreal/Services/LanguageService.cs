using System;
using System.Collections.Generic;

namespace EdgarJairVazquezVillarreal.Services
{
    public class LanguageService
    {
        public bool IsSpanish { get; private set; } = true;

        public event Action? OnLanguageChanged;

        public void ToggleLanguage()
        {
            IsSpanish = !IsSpanish;
            OnLanguageChanged?.Invoke();
        }

        public string Get(string key) =>
            _d.TryGetValue(key, out var t) ? (IsSpanish ? t.ES : t.EN) : key;

        // ──────────────────────────────────────────────────────────────────────
        // DICCIONARIO BILINGÜE
        // Convención de prefijos:
        //   Nav*      → NavMenu / global
        //   Home*     → Página "Sobre mí"
        //   Proj*     → Página "Proyectos"
        //   Exp*      → Página "Experiencia"
        //   Contact*  → Página "Contacto"
        // ──────────────────────────────────────────────────────────────────────
        private readonly Dictionary<string, (string ES, string EN)> _d = new()
        {
            // ══════════════════════════════════════════
            //  NAVEGACIÓN / GLOBAL
            // ══════════════════════════════════════════
            { "NavAboutMe",     ("Sobre mí",   "About Me")   },
            { "NavProjects",    ("Proyectos",  "Projects")   },
            { "NavExperience",  ("Experiencia","Experience")  },
            { "NavContact",     ("Contacto",   "Contact")    },
            { "DownloadCV",     ("Descargar CV","Download CV") },
            { "DownloadCVFull", ("Descargar CV Completo","Download Full CV") },
            { "NotFoundTitle",  ("Página no encontrada", "Page not found") },
            { "NotFoundText",
                ("La dirección que buscas no existe o cambió de lugar.",
                 "The page you are looking for doesn't exist or has moved.") },
            { "BackHome",       ("Volver al inicio", "Back to home") },
            { "ViewDocs",       ("Ver Documentación Completa","View Full Documentation") },

            // ══════════════════════════════════════════
            //  HOME — Sobre mí
            // ══════════════════════════════════════════
            { "HomeTitle", ("Sobre Mí", "About Me") },

            // Hero
            { "HeroGreeting", ("Hola, soy", "Hi, I'm") },
            { "HeroRole1",    ("Ingeniero en Mecatrónica",             "Mechatronics Engineer")            },
            { "HeroRole2",    ("Arranque de líneas de producción",     "Production line commissioning")    },
            { "HeroRole3",    ("Desarrollador C# / .NET",              "C# / .NET Developer")              },
            { "HeroRole4",    ("Automatización industrial y robótica", "Industrial automation & robotics") },
            { "HeroTagline", (
                "Trabajo en los dos lados de la automatización: en piso, instalando y arrancando líneas de producción, y en software, construyendo las herramientas que conectan ambos.",
                "I work on both sides of automation: on the floor, installing and commissioning production lines, and in software, building the tools that connect the two.") },
            { "ViewProjects",   ("Ver proyectos", "View projects") },
            { "HeroCodeDegree", ("Mecatrónica",   "Mechatronics")  },

            // Cifras
            { "StatErp",       ("Sistemas ERP desarrollados",      "ERP systems built")         },
            { "StatEndpoints", ("Endpoints REST en VAVILL",        "REST endpoints in VAVILL")  },
            { "StatTests",     ("Pruebas automatizadas en CNCIMS", "Automated tests in CNCIMS") },
            { "StatCswp",      ("Certificación SOLIDWORKS",        "SOLIDWORKS certification")  },

            { "BioP1", (
                "Soy ingeniero en mecatrónica con experiencia en instalación y arranque de líneas de producción automotriz, y desarrollador de software industrial en C# / .NET. Mi día a día mezcla el conexionado eléctrico de tableros, sensores y motores, las pruebas funcionales y el power-up de equipos con la coordinación de materiales y cambios de ingeniería.",
                "I'm a mechatronics engineer with experience installing and commissioning automotive production lines, and an industrial software developer in C# / .NET. My day-to-day mixes electrical wiring of panels, sensors and motors, functional testing and equipment power-up with coordinating materials and engineering changes.") },
            { "BioP2", (
                "En paralelo diseño y programo mis propias soluciones: desde un ERP modular y un punto de venta en producción hasta el software CAM y el firmware de una estación CNC de grabado. Me gusta la presión de los proyectos: encontrar la solución y sacarlos adelante.",
                "Alongside that, I design and build my own solutions: from a modular ERP and a point of sale running in production to the CAM software and firmware of a CNC engraving station. I enjoy the pressure of projects: finding the solution and getting them over the line.") },
            { "BioGoalLabel", ("Hacia dónde voy", "Where I'm headed") },
            { "BioGoal", (
                "De electromecánico a controles y robótica, y de ahí a la integración de sistemas MES / IT.",
                "From electromechanical work to controls and robotics, and from there to MES / IT systems integration.") },

            // Proyectos destacados
            { "HomeFeaturedTitle", ("Proyectos destacados",    "Featured projects") },
            { "HomeAllProjects",   ("Ver todos los proyectos", "View all projects") },

            // Habilidades (el detalle de cada tarjeta vive en Home.razor)
            { "HomeSkillsTitle", ("Habilidades",      "Skills")           },
            { "LanguagesTitle",  ("Idiomas",          "Languages")        },
            { "LangSpanish",     ("Español (nativo)", "Spanish (native)") },
            { "LangEnglish",     ("Inglés (B2)",      "English (B2)")     },

            // Logros y participaciones
            { "CareerAndAchievements", ("Logros y Participaciones", "Achievements & Participations") },
            { "RoboticsSkills",        ("Robótica Competitiva",     "Competitive Robotics")          },
            { "TechnologicalInnovation",("Innovación Tecnológica",  "Technological Innovation")      },

            { "RobotBattle2018", ("Robot Battle 2018", "Robot Battle 2018") },
            { "ParticipationWithTeamDynamo",
                ("Participación con equipo Dynamo",
                 "Participation with Team Dynamo") },

            { "RobotCIM", ("Robot CIM 2019", "Robot CIM 2019") },
            { "ParticipationWithTeamDynamoInCategories",
                ("Categorías Combat y Mini-sumo con equipo Dynamo",
                 "Combat and Mini-sumo categories with Team Dynamo") },

            { "StateRoboticsNL", ("Estatal de Robótica NL", "NL State Robotics Championship") },
            { "FirstAndSecondPlaceInSumoAndMinisumo",
                ("1er y 2do lugar en categorías Sumo y Mini-sumo",
                 "1st and 2nd place in Sumo and Mini-sumo categories") },

            { "ParticipationScienceFair2019",
                ("Feria de Ciencias Estatal NL 2019 – proyecto de automatización",
                 "NL State Science Fair 2019 – automation project") },

            { "ParticipationScienceFair2020",
                ("Feria de Ciencias Estatal NL 2020 – proyecto de control embebido",
                 "NL State Science Fair 2020 – embedded control project") },

            // ══════════════════════════════════════════
            //  PROJECTS — Proyectos
            // ══════════════════════════════════════════
            { "ProjectsTitle", ("Proyectos", "Projects") },
            { "ProjAcademicTitle",
                ("Proyectos Académicos Destacados",
                 "Featured Academic Projects") },

            // EsmeraldaPoint
            { "ProjEsmeraldaSubtitle",
                ("Sistema de Punto de Venta y ERP",
                 "Point of Sale and ERP System") },
            { "ProjEsmeraldaDesc",
                ("Sistema empresarial completo desarrollado desde cero para una tortillería. Cubre ventas, inventario, recursos humanos, proveedores y finanzas, con arquitectura distribuida entre dos ciudades.",
                 "Full-featured business system built from scratch for a tortilla manufacturer. Covers sales, inventory, HR, suppliers and finance, with a distributed architecture across two cities.") },

            // VAVILL
            { "ProjVavillSubtitle", 
                ("ERP Empresarial Completo — Manufactura e Industrial", 
                 "Complete Business ERP — Manufacturing and Industrial") },
            { "ProjVavillDesc", 
                ("Sistema ERP completo desarrollado en .NET 8 con arquitectura modular. Integra gestión de recursos humanos, activos IT, cumplimiento normativo CTPAT, control de producción con métricas OEE y módulo de mantenimiento industrial con KPIs en tiempo real.", 
                 "Complete ERP system developed in .NET 8 with modular architecture. Integrates human resources, IT assets, CTPAT regulatory compliance, production control with OEE metrics, and an industrial maintenance module with real-time KPIs.") },
            { "StatusInDevelopment",
                ("En desarrollo activo", 
                 "In active development") },

            // CNCIMS
            { "ProjCncSubtitle",
                ("Estación CNC de grabado con software CAM propio",
                 "CNC engraving station with custom CAM software") },
            { "ProjCncDesc",
                ("Conversión de una cortadora láser CO2 recuperada en una estación CNC de grabado mecánico para placas de identificación de tableros. Puesta en marcha completa: hardware, firmware y una aplicación CAM de escritorio.",
                 "Conversion of a salvaged CO2 laser cutter into a mechanical CNC engraving station for control panel nameplates. Full bring-up: hardware, firmware and a desktop CAM application.") },

            // Secciones y botones de Proyectos (el detalle de cada tarjeta vive en Projects.razor)
            { "ProjMoreTitle",   ("Más proyectos",     "More projects")      },
            { "ProjOthersTitle", ("Otros proyectos",   "Other projects")     },
            { "ViewDocsShort",   ("Ver documentación", "View documentation") },
            { "ViewDemo",        ("Ver demo",          "View demo")          },

            // ══════════════════════════════════════════
            //  EXPERIENCE — Experiencia
            // ══════════════════════════════════════════
            { "ExpSubtitle",
                ("Un recorrido por mi evolución técnica en la industria y el desarrollo de software.",
                 "A journey through my technical evolution in industry and software development.") },

            { "Exp1Status",  ("Finalizado", "Completed") },
            { "Exp1Title",
                ("Residente de Desarrollo / IT – Área de Ingeniería",
                 "Development / IT Engineer – Engineering Department") },
            { "Exp1Company", ("Julian Electric de México", "Julian Electric de México") },
            { "Exp1Intro",   ("Responsabilidades y logros:", "Responsibilities and achievements:") },

            { "Exp1B1",
                ("Diseño e implementación de un sistema de apoyo visual basado en tiras LED para líneas de producción, orientado a reducción de errores operativos y mejora en la identificación de estaciones críticas.",
                 "Design and implementation of an LED strip-based visual support system for production lines, aimed at reducing operational errors and improving identification of critical stations.") },
            { "Exp1B2",
                ("Desarrollo de tarjeta electrónica de control para proyectos internos (alimentación 24V, integración con relevadores, optoacopladores y microcontrolador ESP32).",
                 "Development of an electronic control board for internal projects (24V power supply, integration with relays, optocouplers, and ESP32 microcontroller).") },
            { "Exp1B3",
                ("Programación y desarrollo de aplicaciones internas utilizando C# y .NET, con integración a base de datos SQL para gestión y trazabilidad de información.",
                 "Programming and development of internal applications using C# and .NET, with SQL database integration for information management and traceability.") },
            { "Exp1B4",
                ("Desarrollo de una aplicación de gestión de equipos para control, registro y seguimiento de activos en planta.",
                 "Development of an equipment management application for control, registration, and tracking of plant assets.") },
            { "Exp1B5",
                ("Implementación de mejoras bajo metodología Lean Six Sigma, enfocadas en reducción de scrap, optimización de procesos y disminución de tiempos muertos.",
                 "Implementation of improvements under Lean Six Sigma methodology, focused on scrap reduction, process optimization, and downtime reduction.") },
            { "Exp1B6",
                ("Gestión y atención de tickets técnicos del departamento de IT, brindando soporte a líneas de producción y resolviendo incidencias eléctricas, electrónicas y de control.",
                 "Management and resolution of IT department technical tickets, providing support to production lines and resolving electrical, electronic, and control incidents.") },
            { "Exp1B7",
                ("Diseño e implementación de conexiones neumáticas para integración de actuadores en estaciones automatizadas.",
                 "Design and implementation of pneumatic connections for actuator integration in automated stations.") },

            { "Exp1B8",
                ("Programación de PLC, robótica FANUC, SCADA y seguimiento de OEE; actividades de calidad bajo IATF 16949.",
                 "PLC programming, FANUC robotics, SCADA and OEE tracking; quality activities under IATF 16949.") },
            { "Exp1Location", ("Saltillo, Coahuila", "Saltillo, Coahuila, Mexico") },

            { "ExpWorkTitle", ("Experiencia laboral",      "Work experience")           },
            { "ExpEduTitle",  ("Formación académica",      "Education")                 },
            { "ExpCertTitle", ("Certificaciones y cursos", "Certifications & courses")  },

            // Puesto actual. No se publica cliente final, proyecto ni planta: se describe en genérico.
            { "Exp0Status",   ("Actual", "Current") },
            { "Exp0Title",    ("Técnico Electromecánico", "Electromechanical Technician") },
            { "Exp0Company",  ("Magna · CIMS (Cosma International)", "Magna · CIMS (Cosma International)") },
            { "Exp0Period",   ("Jun 2026 – actual", "Jun 2026 – present") },
            { "Exp0Location",
                ("Saltillo, Coahuila · asignado a una planta en EE. UU.",
                 "Saltillo, Mexico · assigned to a plant in the USA") },
            { "Exp0B1",
                ("Instalación y arranque de líneas de producción automotriz: conexionado eléctrico de tableros, sensores y motores; pruebas funcionales, I/O check y power-up.",
                 "Installation and commissioning of automotive production lines: electrical wiring of panels, sensors and motors; functional testing, I/O check and power-up.") },
            { "Exp0B2",
                ("Coordinación de materiales y cambios de ingeniería para que las líneas avancen; control de inventario contra BOM (cable, manguera, conectores, guardas).",
                 "Coordination of materials and engineering changes to keep the lines moving; inventory control against the BOM (cable, hose, connectors, guarding).") },
            { "Exp0B3",
                ("Cuadre del layout eléctrico contra diagramas de red, I/O y alimentación.",
                 "Reconciling the electrical layout against network, I/O and power diagrams.") },
            { "Exp0B4",
                ("Desarrollo de una estación CNC de grabado: hardware, firmware y software CAM propio.",
                 "Development of a CNC engraving station: hardware, firmware and custom CAM software.") },
            { "Exp0B5",
                ("Producción de placas de identificación (lamicoid) con láser de diodo.",
                 "Production of nameplates (lamicoid) with a diode laser.") },
            { "Exp0B6",
                ("Operación de robots KUKA y FANUC.",
                 "Operation of KUKA and FANUC robots.") },

            // Formación (datos del CV)
            { "Edu1Degree",    ("Ingeniería en Mecatrónica", "Mechatronics Engineering") },
            { "Edu1Specialty",
                ("Especialidad en Automatización de Procesos de Manufactura",
                 "Specialization in Manufacturing Process Automation") },
            { "Edu1School",    ("Instituto Tecnológico de Saltillo", "Instituto Tecnológico de Saltillo") },
            { "Edu1Location",  ("Saltillo, Coahuila",  "Saltillo, Coahuila, Mexico") },
            { "Edu1B1",
                ("Coordinación de equipos de trabajo para proyectos académicos integrales.",
                 "Coordinated work teams for comprehensive academic projects.") },

            { "Edu2School",    ("Instituto Central Coahuila", "Instituto Central Coahuila") },
            { "Edu2Location",  ("Monclova, Coahuila",  "Monclova, Coahuila, Mexico") },
            { "Edu2B1",
                ("Líder del equipo de robótica “Dynamo”: coordinación de 10 personas para competencias estatales y nacionales.",
                 "Leader of the “Dynamo” robotics team: coordinated 10 people for state and national competitions.") },

            // ══════════════════════════════════════════
            //  CONTACT — Contacto
            // ══════════════════════════════════════════
            { "ContactHero",     ("¿Hablamos?",  "Let's Talk?")  },
            { "ContactSubtitle",
                ("Estoy disponible para nuevos proyectos, consultoría o simplemente para conectar.",
                 "I'm available for new projects, consulting, or simply to connect.") },

            { "ContactEmailTitle", ("Correo Electrónico", "Email") },
            { "ContactEmailDesc",  ("Para consultas detalladas o propuestas.", "For detailed inquiries or proposals.") },
            { "ContactEmailBtn",   ("Enviar Correo",  "Send Email")   },

            { "ContactLinkedInDesc", ("Conectemos profesionalmente.", "Let's connect professionally.") },
            { "ContactLinkedInBtn",  ("Ver Perfil", "View Profile")  },

            { "ContactGitHubDesc",
                ("Explora el código de mis proyectos open source y contribuciones.",
                 "Explore my open source projects and contributions.") },
        };
    }
}
