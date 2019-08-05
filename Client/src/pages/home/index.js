import React, { Component } from "react"
import { ToastAndroid, TouchableOpacity } from "react-native"
import styled from "styled-components/native"
import Icon from "react-native-vector-icons/MaterialIcons"

import Tabs from "./Tabs"
import Card from "./Card"
import Modal from "../../helpers/Components/Modal"
import AtividadeService from "../../services/AtividadeService"
import TarefaService from "../../services/TarefaService"
import FechamentoService from "../../services/FechamentoService"
import TarefasList from "../../models/list/TarefasList"
import CurrentUser from "../../helpers/CurrentUser"
import Atividade from "../../models/Atividade"

export default class App extends Component {
  constructor() {
    super()
    this.modalControl
    this.TarefaService = new TarefaService()
    this.atividadeService = new AtividadeService()
    this.FechamentoService = new FechamentoService()
    this.listaTarefas = new TarefasList()
    this.state = {
      ListaTarefasRealizadas: this.listaTarefas.buscaRealizadas(),
      ListaTarefasNaoRealizadas: this.listaTarefas.buscaNaoRealizadas(),
      ValorTotalSemanaAtual: 0.0
    }
  }

  static navigationOptions = ({ navigation }) => {
    return {
      headerRight: (
        <TouchableOpacity onPress={() => navigation.navigate("Relatorio")}>
          <Icon name="list" size={28} color="#000" />
        </TouchableOpacity>
      )
    }
  }

  componentWillMount() {
    this.MontaListaTarefa()
    this.BuscaValorTotalSemanaAtual()
  }

  async BuscaValorTotalSemanaAtual() {
    const ValorTotalSemanaAtual = await this.FechamentoService.buscaValorTotalSemanaAtual()
    await this.setState({ ValorTotalSemanaAtual })
  }

  async MontaListaTarefa() {
    const tarefas = await this.TarefaService.BuscaTodos()
    await tarefas.map(tarefa => this.listaTarefas.adicionaNaoRealizada(tarefa))
    const atividades = await this.atividadeService.BuscaAtividadesDeHoje()
    await this.listaTarefas.separaRealizadasENaoRealizadas(atividades)
    this.atualizaStateListaTarefa()
  }

  async cadastraAtividadeComTarefa(tarefa) {
    const pessoa = await CurrentUser.get()
    const atividade = await new Atividade(null, new Date(), pessoa, tarefa)
    this.atividadeService.Cadastra(atividade)
  }

  AbrirTelaCadastrarAtividade() {
    this.props.navigation.navigate("AtividadesCreate")
  }

  abrirTelaAtividades() {
    this.props.navigation.navigate("Atividades")
  }

  atualizaStateListaTarefa() {
    this.setState({
      ListaTarefasRealizadas: this.listaTarefas.buscaRealizadas(),
      ListaTarefasNaoRealizadas: this.listaTarefas.buscaNaoRealizadas()
    })
  }

  render() {
    return (
      <Container>
        <Menu>
          <Tabs
            openModal={data => this.modalControl.open(data)}
            TarefasList={this.state.ListaTarefasNaoRealizadas}
            AbrirTelaCadastrarAtividade={this.AbrirTelaCadastrarAtividade.bind(
              this
            )}
          />
          <Card
            TarefasList={this.state.ListaTarefasRealizadas}
            abrirTelaAtividades={this.abrirTelaAtividades.bind(this)}
            ValorTotalSemana={this.state.ValorTotalSemanaAtual}
          />
        </Menu>
        <Modal
          Header="Cadastrar atividade"
          Body="Realmente deseja criar esta atividade?"
          refe={control => (this.modalControl = control)}
          onConfirm={async tarefa => {
            try {
              await this.cadastraAtividadeComTarefa(tarefa)
              this.listaTarefas.atualizaTarefaRealizada(tarefa)
              this.atualizaStateListaTarefa()
              this.BuscaValorTotalSemanaAtual()
              ToastAndroid.show(
                `tarefa ${tarefa.Nome} cadastrada com sucesso`,
                ToastAndroid.LONG
              )
            } catch (error) {
              console.log(error)
              ToastAndroid.show(
                `tarefa ${tarefa.Nome} não foi cadastrada com sucesso`,
                ToastAndroid.LONG
              )
            }
          }}
        />
      </Container>
    )
  }
}

const Container = styled.View`
  flex: 1;
  background: #493f85;
  margin-top: 55px;
`
const Menu = styled.View``

const ButtonReload = styled.TouchableOpacity`
  width: 105px;
  height: 45px;
  padding: 12px;
  border-radius: 10px;
  background-color: rgb(0, 255, 0);
`

const TextButton = styled.Text``
