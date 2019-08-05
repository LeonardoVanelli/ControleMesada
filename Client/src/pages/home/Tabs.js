import React, { Component } from "react"
import styled from "styled-components/native"
import Icon from "react-native-vector-icons/MaterialIcons"

import AtividadeService from "../../services/AtividadeService"

export default class Tabs extends Component {
  render() {
    return (
      <TabsContainer>
        {this.props.TarefasList.map(tarefa => (
          <TabsItem
            tarefa={tarefa}
            key={tarefa.Id}
            openModal={this.props.openModal}
          />
        ))}
        <TabItem onTouchEnd={() => this.props.AbrirTelaCadastrarAtividade()}>
          <TabText>Datas diferente</TabText>
          <Icon name="add" size={25} color="#fff" />
        </TabItem>
      </TabsContainer>
    )
  }
}

class TabsItem extends Component {
  constructor() {
    super()
    this.AtividadeService = new AtividadeService()
  }

  render() {
    return (
      <TabItem onTouchEnd={() => this.props.openModal(this.props.tarefa)}>
        <TabText>{this.props.tarefa.Nome}</TabText>
        <Icon name="check" size={25} color="#fff" />
      </TabItem>
    )
  }
}

const TabsContainer = styled.ScrollView.attrs({
  horizontal: true,
  contentContainerStyle: { paddingLeft: 10, paddingRight: 20 },
  showsHorizontalScrollIndicator: false
})`
  padding-top: 20px;
`

const TabItem = styled.View`
  width: 100px;
  height: 100px;
  background: rgba(255, 255, 255, 0.3);
  border-radius: 3px;
  margin-left: 10px;

  padding: 10px;
  justify-content: space-between;
`

const TabText = styled.Text`
  color: #fff;
  font-size: 17px;
  font-family: "Courier New";
`
