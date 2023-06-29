# LTraceFilter
Repositório do software de filtragem desenvolvido para o processo seletivo da empresa LTrace

### Arquitetura
- Buscou-se seguir os padrões arquiturais da clean-architecture e SOLID;
- O padrão Dependency Injection foi utilizado em todas as classes da aplicação; 
- O software está dividio em 3 camadas arquiteturais: Business, Data e Presentation. 
- Na camada Business encontram-se todas as regras de negócio da aplicação;
- Na camada Data encontra-se as classes responsáveis por persistências;
- Na Camada Presentation encontra-se todo o código responsável pela interface gráfica da aplicação;
- A camada Business está totalmente desacoplada das demais camadas, de maneira que alterações na interface gráfica ou na persistência tem impacto zero na camada de négócio;
- Na camada de Presentation é utilizado o padrão arquitetural Model-View-Presenter (MVP);

## Testes
Foi escrito um teste de unidade para a classe BandPassFilter. Os testes unitários estão configurados para serem executados a cada compilação. Ao final do log da compilação é exebido o resultado dos testes como também o resultado da cobertura dos testes.
