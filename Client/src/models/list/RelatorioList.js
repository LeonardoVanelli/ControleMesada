export default class RelatorioList {
  constructor() {
    this._relatorios = []
    Object.freeze(this)
  }

  get relatorios() {
    return this._relatorios.slice()
  }

  adiciona(relatorio) {
    this._relatorios.push(relatorio)
  }

  limpa() {
    this._relatorios.length = 0
  }

  get relatorioPorDia() {
    if (this.relatorios.length == 0)
      throw new Error("Nenhum registro para esta semana")

    datas = this.getDatas(this.relatorios)
    let relatoriosPorDia = []
    datas.map(data => {
      relatoriosPorDia.push(this.getRelatoriosByDate(data))
    })
    return relatoriosPorDia
  }

  getRelatoriosByDate(data) {
    return this.relatorios.filter(relatorio =>
      this.mesmaHoraDiaMes(relatorio.DataRealizada, data)
    )
  }

  getDatas(relatorioList) {
    let anterior = relatorioList[0].DataRealizada
    let datas = []
    relatorioList.map(relatorio => {
      if (this.mesmaHoraDiaMes(relatorio.DataRealizada, anterior)) {
        anterior = relatorio.DataRealizada
      } else {
        datas.push(anterior)
        anterior = relatorio.DataRealizada
      }
    })

    datas.push(anterior)
    return datas
  }

  mesmaHoraDiaMes(data, dataAnterior) {
    return data.toLocaleDateString() == dataAnterior.toLocaleDateString()
  }
}
