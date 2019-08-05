export default class TarefasList {
  constructor() {
    this.TarefasRealizadas = []
    this.TarefasNãoRealizadas = []
    Object.freeze(this)
  }

  async separaRealizadasENaoRealizadas(atividades) {
    await atividades.map(atividade => {
      this.TarefasNãoRealizadas.map(tarefa => {
        if (atividade.Tarefa.Id == tarefa.Id) {
          this.atualizaTarefaRealizada(tarefa)
        }
      })
    })
    return this
  }

  buscaRealizadas() {
    return this.TarefasRealizadas.map(tarefa => tarefa)
  }

  buscaNaoRealizadas() {
    return this.TarefasNãoRealizadas.map(tarefa => tarefa)
  }

  atualizaTarefaRealizada(tarefa) {
    this.TarefasRealizadas.push(tarefa)
    this.removeNaoRealizada(tarefa)
  }

  adicionaNaoRealizada(tarefa) {
    this.TarefasNãoRealizadas.push(tarefa)
  }

  removeNaoRealizada(tarefa) {
    let index = this.TarefasNãoRealizadas.indexOf(tarefa)
    this.TarefasNãoRealizadas.splice(index, 1)
  }

  limpa() {
    this.TarefasRealizadas = []
    this.TarefasNãoRealizadas = []
  }
}
