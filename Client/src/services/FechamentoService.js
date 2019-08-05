import HttpService from "./HttpService"
import Fechamento from "../models/Fechamento"
import RelatorioList from "../models/list/RelatorioList"

export default class FechamentoService {
  constructor() {
    this._HttpService = new HttpService()
  }

  buscaValorTotalSemanaAtual() {
    return this._HttpService
      .get(
        `ValorTarefaRest/BuscaValorToralSemanaPorData?data=${new Date().toJSON()}`
      )
      .then(valorTotal => valorTotal.toFixed(2))
  }

  async buscaTotasAtividadesSemana(date) {
    let relatoriosObj = await this._HttpService.get(
      `FechamentoRest/GetAllOfWeek?data=${date.toJSON()}`
    )
    let relatoriosList = new RelatorioList()
    await relatoriosObj.map(relatorioObj => {
      let relatorio = new Fechamento(
        relatorioObj.DataRealizada,
        relatorioObj.Nome,
        relatorioObj.Valor
      )
      relatoriosList.adiciona(relatorio)
    })
    return relatoriosList
  }
}
