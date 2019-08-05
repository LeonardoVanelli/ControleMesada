export default class AtividadesList {
  constructor() {
    this.Atividades = []
  }

  adiciona(atividade) {
    this.Atividades.push(atividade)
  }

  get() {
    return this.Atividades.map(atividade => atividade)
  }
}
