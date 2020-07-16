# NT1-20-1C-12B-HistorasClinicas
**Descripción general:**

Sistema de gestión de historias clínicas de los pacientes pertenecientes a un centro médico.

**Modelos:**
1. Paciente
2. Administrativo
3. Medico
4. Historia Clínica
5. Episodio
6. Evoluciones
7. Epicrisis &#39; Diagnostico

Un **paciente** tiene
- una Historia Clínica

Un **Administrativo**
- Tiene un código de empleado

Un **médico** tiene:
- Tiene un código de empleado
- Una especialidad

Una **Historia Clínica** tiene:
- Un paciente
- Episodios

Un **Episodio** tiene:
- Motivo
- Descripción
- Evoluciones
- Estado abierto cerrado
- Una Epicrisis con diagnóstico. Una vez cargada la epicrisis, el episodio queda cerrado.

Una **evolución** tiene:
- Un medico
- Fecha y hora de inicio
- Fecha y hora de fin
- Una descripción de lo que se realizó
- Estado abierto cerrado

Una **Epicrisis** tiene:
- Una historia clínica
- Una fecha y hora de carga
- Diagnostico
- Recomendaciones
- Notas

**Se requiere que:**
1. Se puedan cargar y administrar
  - pacientes
  - médicos
  - Historias clínicas (una por paciente) (Una vez creada no puede eliminarse)
  - Administrativo, solo en caso de grupo de 5, sinó puede desarrollar las tareas de este cualquier medico

2. Las pacientes pueden ver solo sus historias clínicas.
3. Un administrativo
  - Puede cargar nuevos pacientes y administrarlos
4. Los médicos pueden cargar episodios
  - Si no existe una HC, se debe crear.
5. Los médicos pueden cargar evoluciones (Ej. atenciones en consultorio, Rayos X, etc.)
  - Si dispone de un episodio abierto, se agrega a dicho episodio.
  - Si el último episodio está cerrado, se debe crear uno nuevo.
  - No puede existir más de un episodio abierto en simultaneo.
6. Los médicos pueden cargar Epicrisis con un diagnostico
  - Al menos debe existir una evolución en el episodio.
  - Una vez cargada la epicrisis quedará automáticamente cerrado el episodio.
  - Solo se podrán agregar notas adicionales en la Epicrisis, pero no se podrá modificar nada, ni agregar más eventos al episodio.
