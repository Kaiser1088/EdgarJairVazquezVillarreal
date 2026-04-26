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
            { "DocsPending",    ("Documentación (Pendiente)","Documentation (Pending)") },
            { "ViewDocs",       ("Ver Documentación Completa","View Full Documentation") },

            // ══════════════════════════════════════════
            //  HOME — Sobre mí
            // ══════════════════════════════════════════
            { "HomeTitle", ("Sobre Mí", "About Me") },

            { "BioP1", (
                "Ingeniero en Mecatrónica con enfoque en el desarrollo e implementación de soluciones tecnológicas para entornos industriales. Cuento con experiencia en integración de software, electrónica y sistemas de control, orientados a mejorar la eficiencia y el desempeño de procesos productivos.",
                "Mechatronics Engineer focused on developing and implementing technological solutions for industrial environments. I have experience in software integration, electronics, and control systems, aimed at improving the efficiency and performance of production processes.") },

            { "BioP2", (
                "Me caracterizo por una sólida capacidad analítica, pensamiento estructurado y facilidad para adaptarme a nuevos retos. Disfruto resolver problemas desde una perspectiva práctica, proponiendo soluciones funcionales y enfocadas en resultados.",
                "I stand out for strong analytical capacity, structured thinking, and easy adaptation to new challenges. I enjoy solving problems from a practical perspective, proposing functional and result-focused solutions.") },

            { "BioP3", (
                "Tengo interés en el aprendizaje continuo y en la aplicación de nuevas tecnologías para optimizar procesos. Valoro el trabajo en equipo y la colaboración como elementos clave para el desarrollo de proyectos exitosos.",
                "I am interested in continuous learning and applying new technologies to optimize processes. I value teamwork and collaboration as key elements for successful project development.") },

            { "BioP4", (
                "Busco seguir creciendo profesionalmente en áreas relacionadas con automatización, desarrollo tecnológico e integración de sistemas, aportando valor a través de soluciones eficientes y bien estructuradas.",
                "I aim to keep growing professionally in areas related to automation, technological development, and systems integration, bringing value through efficient and well-structured solutions.") },

            // Habilidades
            { "MechatronicsTitle", ("Mecatrónica",  "Mechatronics") },
            { "SoftwareTitle",     ("Software",     "Software")     },
            { "SolutionsTitle",    ("Soluciones",   "Solutions")    },

            { "Solidworks",    ("SOLIDWORKS (Certificado CSWP)", "SOLIDWORKS (CSWP Certified)")   },
            { "PLC",           ("Programación de PLC Siemens",  "Siemens PLC Programming")        },
            { "PCB",           ("Diseño de PCB (ESP32-S3)",     "PCB Design (ESP32-S3)")          },
            { "Labview",       ("LabVIEW & MATLAB",             "LabVIEW & MATLAB")               },
            { "CSharp",        ("C# / .NET 10 & Blazor",        "C# / .NET 10 & Blazor")          },
            { "AspNetCore",    ("ASP.NET Core 10",              "ASP.NET Core 10")                },
            { "ClientServer",  ("Arquitectura Cliente-Servidor","Client-Server Architecture")      },
            { "IndApps",       ("Apps Industriales",            "Industrial Apps")                },
            { "WPF",           ("WPF Desktop Apps",             "WPF Desktop Apps")               },
            { "HWInt",         ("Integración con Hardware",     "Hardware Integration")           },
            { "RestAPI",       ("REST APIs / Web Services",     "REST APIs / Web Services")       },
            { "SQL",           ("SQL Server",                   "SQL Server")                     },
            { "Postgres",      ("PostgreSQL & EF Core 10",      "PostgreSQL & EF Core 10")        },
            { "Git",           ("Git & Control de Versiones",   "Git & Version Control")          },
            { "CTPAT",         ("Sistemas CTPAT",               "CTPAT Systems")                  },
            { "ZPL",           ("Automatización ZPL",           "ZPL Automation")                 },
            { "ITInv",         ("Gestión de Inventarios IT",    "IT Inventory Management")        },

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

            // App de Gestión
            { "ProjMgmtTitle",  ("App de Gestión Empresarial", "Business Management App") },
            { "ProjMgmtDesc",
                ("Plataforma integral diseñada para la administración de activos, control de inventarios IT y automatización de flujos de trabajo empresariales.",
                 "Comprehensive platform designed for asset management, IT inventory control, and business workflow automation.") },
            { "ProjMgmtB1",
                ("Implementación de módulos para cumplimiento CTPAT.",
                 "Implementation of CTPAT compliance modules.") },
            { "ProjMgmtB2",
                ("Gestión de bases de datos relacionales en SQL Server.",
                 "Relational database management with SQL Server.") },

            // Controlador Hardware
            { "ProjHardwareTitle", ("Controlador de Hardware Industrial", "Industrial Hardware Controller") },
            { "ProjHardwareDesc",
                ("Diseño y prototipado de una PCB personalizada basada en el microcontrolador ESP32-S3 para aplicaciones de control y monitoreo industrial.",
                 "Design and prototyping of a custom PCB based on the ESP32-S3 microcontroller for industrial control and monitoring applications.") },
            { "ProjHardwareB1",
                ("Integración de periféricos y protocolos de comunicación IoT.",
                 "Integration of peripherals and IoT communication protocols.") },
            { "ProjHardwareB2",
                ("Modelado mecánico de componentes y ensamblaje.",
                 "Mechanical modeling of components and assembly.") },

            // Sistema ZPL
            { "ProjZPLTitle", ("Sistema de Etiquetado ZPL", "ZPL Labeling System") },
            { "ProjZPLDesc",
                ("Desarrollo de una solución en C# para la generación dinámica de etiquetas en formato ZPL, optimizando procesos de impresión en líneas de producción.",
                 "Development of a C# solution for dynamic ZPL label generation, optimizing printing processes on production lines.") },
            { "ProjZPLB1",
                ("Comunicación directa con impresoras industriales de etiquetas.",
                 "Direct communication with industrial label printers.") },
            { "ProjZPLB2",
                ("Estandarización de formatos para logística y envíos.",
                 "Format standardization for logistics and shipping.") },

            // Brazo Robótico
            { "ProjRobotArmTitle", ("Brazo Robótico de 6 Ejes", "6-Axis Robotic Arm") },
            { "ProjRobotArmDesc",
                ("Diseño 3D integral y construcción física de un manipulador robótico. Implementación de algoritmos de cinemática para control de precisión. (Diseños y prototipo funcional).",
                 "Full 3D design and physical construction of a robotic manipulator. Implementation of kinematics algorithms for precision control. (Designs and functional prototype).") },

            // Sorteador de Obstáculos
            { "ProjObstacleTitle", ("Diseño Sorteador de Obstáculos", "Obstacle Avoidance Vehicle") },
            { "ProjObstacleDesc",
                ("Vehículo capaz de sortear obstáculos utilizando sensores ultrasónicos. Implementación de control PID para corrección de trayectoria y movimientos suaves.",
                 "Vehicle capable of avoiding obstacles using ultrasonic sensors. PID control implementation for trajectory correction and smooth movements.") },

            // Péndulo Invertido
            { "ProjPendulumTitle", ("Péndulo Invertido", "Inverted Pendulum") },
            { "ProjPendulumDesc",
                ("Sistema mecatrónico tipo \"Balancín\". Aplicación de teoría de control avanzada para estabilizar verticalmente un sistema inestable mediante retroalimentación.",
                 "Mechatronic \"Rocker\" system. Application of advanced control theory to vertically stabilize an unstable system through feedback.") },

            // Control de Flujos
            { "ProjFlowTitle", ("Control de Flujos de Caudal", "Flow Rate Control System") },
            { "ProjFlowDesc",
                ("Proyecto de control de procesos enfocado en la regulación y automatización de flujo de caudal en sistemas hidráulicos, aplicando teoría de control clásico.",
                 "Process control project focused on the regulation and automation of flow rate in hydraulic systems, applying classical control theory.") },

            // ══════════════════════════════════════════
            //  EXPERIENCE — Experiencia
            // ══════════════════════════════════════════
            { "ExpSubtitle",
                ("Un recorrido por mi evolución técnica en la industria y el desarrollo de software.",
                 "A journey through my technical evolution in industry and software development.") },

            { "Exp1Status",  ("Finalizado", "Completed") },
            { "Exp1Title",
                ("Ingeniero de Desarrollo / IT – Área de Ingeniería",
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

            { "ContactPhoneTitle", ("Teléfono", "Phone") },
            { "ContactPhoneDesc",  ("Disponible para llamadas y mensajes.", "Available for calls and messages.") },
            { "ContactPhoneBtn",   ("Enviar Mensaje", "Send Message") },

            { "ContactLinkedInDesc", ("Conectemos profesionalmente.", "Let's connect professionally.") },
            { "ContactLinkedInBtn",  ("Ver Perfil", "View Profile")  },

            { "ContactGitHubDesc",
                ("Explora el código de mis proyectos open source y contribuciones.",
                 "Explore my open source projects and contributions.") },
        };
    }
}
