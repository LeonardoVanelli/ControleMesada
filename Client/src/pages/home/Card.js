import React, { Component } from "react"
import styled from "styled-components/native"

export default class Card extends Component {
  render() {
    return (
      <CardContainer>
        <HeaderCard>Tarefas ja realizadas hoje</HeaderCard>
        {this.props.TarefasList.map(tarefa => (
          <CardItem Tarefa={tarefa} key={tarefa.Id} />
        ))}
        <CardItemContainer onPress={() => this.props.abrirTelaAtividades()}>
          <CardText>Visualizar de outras datas</CardText>
        </CardItemContainer>
        <BodyCard ValorTotalSemana={this.props.ValorTotalSemana}>
          <GanhoSemana />
        </BodyCard>
      </CardContainer>
    )
  }
}

class BodyCard extends Component {
  render() {
    return (
      <BodyCardContainer>
        <GanhoSemana>
          Você arrecadou <Valor>R${this.props.ValorTotalSemana}</Valor> essa
          semana
        </GanhoSemana>
      </BodyCardContainer>
    )
  }
}

const BodyCardContainer = styled.View`
  padding: 20px;
  background: rgba(55, 55, 55, 0.3);
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px;
`

const GanhoSemana = styled.Text``

const Valor = styled.Text`
  font-weight: bold;
`

class CardItem extends Component {
  render() {
    return (
      <CardItemContainer>
        <CardText>{this.props.Tarefa.Nome}</CardText>
      </CardItemContainer>
    )
  }
}

const CardContainer = styled.ScrollView.attrs({
  contentContainerStyle: { paddingTop: 20 },
  showsHorizontalScrollIndicator: false
})`
  background-color: rgb(255, 255, 255);
  border-radius: 3px;
  margin: 20px;
`

const CardItemContainer = styled.Text`
  border-radius: 3px;
  justify-content: space-between;
  background: rgba(73, 63, 133, 0.2);
  margin-bottom: 10px;
  padding: 10px;
  margin-left: 20px;
  margin-right: 20px;
`

const CardText = styled.Text`
  color: #493f85;
  font-size: 16px;
`
const HeaderCard = styled.Text`
  color: #493f85;
  font-size: 18px;
  font-weight: bold;
  text-align: center;
  margin-bottom: 10px;
  background: rgba(73, 63, 133, 0.2);
  padding-bottom: 10px;
  padding-top: 10px;
  margin-left: 20px;
  margin-right: 20px;
`
