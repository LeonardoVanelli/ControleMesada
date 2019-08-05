import React, { Component } from "react"
import {
  StyleSheet,
  Text,
  View,
  Button,
  Picker,
  ToastAndroid
} from "react-native"
import DateTimePiker from "../../helpers/Components/DateTimePicker"
import AtividadeController from "../../controller/AtividadeController"
import Pessoa from "../../models/Pessoa"
import CurrentUser from "../../helpers/CurrentUser"

export default class App extends Component {
  constructor() {
    super()
    this.AtividadeController = new AtividadeController()
    this.CurrentUser = new CurrentUser()
    this.state = {
      DataRealizada: new Date(),
      Tarefas: [],
      Tarefa: null,
      CurrentUser: new Pessoa()
    }
  }

  componentDidMount() {
    this.AtividadeController.BuscaTarefas().then(tarefas =>
      this.setState({ Tarefas: tarefas })
    )
    CurrentUser.get().then(pessoa => this.setState({ CurrentUser: pessoa }))
  }

  _cadastrar() {
    this.AtividadeController.AdicionarAtividade(
      this.state.DataRealizada,
      this.state.Tarefa
    )
      .then(tarefa => {
        ToastAndroid.show(
          `Tarefa ${tarefa.Tarefa.Nome} cadastrada com sucesso`,
          ToastAndroid.LONG
        )
      })
      .catch(err => {
        ToastAndroid.show(`Opss! Algo deu errado`, ToastAndroid.LONG)
      })
  }

  render() {
    return (
      <View style={styles.container}>
        <Text style={styles.nome}>{this.state.CurrentUser.Nome}</Text>
        <DateTimePiker
          value={this.state.DataRealizada}
          onSelectDate={date => this.setState({ DataRealizada: date })}
        />
        <Picker
          style={styles.tarefa}
          ref={component => (this._tarefaInput = component)}
          selectedValue={this.state.Tarefa}
          onValueChange={(Tarefa, itemIndex) => {
            this.setState({ Tarefa })
          }}>
          <Picker.Item label="Tarefa" value={null} editable={false} />
          {this.state.Tarefas.map(tarefa => {
            return (
              <Picker.Item key={tarefa.Id} label={tarefa.Nome} value={tarefa} />
            )
          })}
        </Picker>
        <Button title="Cadastrar" onPress={this._cadastrar.bind(this)} />
      </View>
    )
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#493F85",
    padding: 10
  },
  nome: {
    color: "white"
  },
  data: {
    color: "black",
    backgroundColor: "#fff"
  },
  tarefa: {
    color: "white"
  }
})
