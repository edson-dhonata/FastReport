### README FAST REPORT ###

- O FastReport funciona da seguinte maneira:

1) Possui um Report Template: Modelo de relatório criado no programa FastReport Designer (Utilitário usado para criar modelo de relatório), salvo no formato .frx.
2) É alimentado através de uma fonte de dados (SQL Server) ou definido no próprio utilitário que gera o relatório .frx.
3) O relatório pode ser visualizado, impresso e salvo nos seguintes formatos: png, jpg, docx, pdf etc. Pode ser apresentado tanto na web (.net Core, Net framework) quanto no desktop.

- Para usar o Fastreport:

É necessário instalar os seguintes pacotes Nugets: 

- FastReport.OpenSource;
- FastReport.OpenSource.Web
- FastReport.OpenSource.Export.PdfSimple

-----------

1) Menu lateral direito > lado direito em Data Source > Actions > New data Source > Fazer conexão e selecionar as tabelas que faram parte do relatório.

2)Criar relacionamento entre tabelas adicionadas caso haja.

  - Menu lateral direito > lado direito em Data Source > Actions > New relation > Definir a realação entre as Pks
  - Após isso a base de dados será adicionada com a relação ai é só montar o relatório.
  - Salvar relatório na pasta de reports da aplicação, como a base de dados já foi implementada será criado o xml no arquivo com o layout.

3)Neste modo e usado via DataTables, para alimentar os dados neste estilo de relatório será necessário a utilização do Nuget: 
  - FastReport.OpenSource.Data.MsSql (Conexão com fonte de dados usando o Designer)
