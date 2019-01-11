import React, { Component } from 'react'
import { connect } from 'react-redux'
import {
  CardDeck,
  Card,
  CardBody,
  CardTitle,
  CardText,
  CardLink
} from 'reactstrap'

import { promiseDispatch } from '../../common'
import { selectResources } from '../resources.selectors'
import { getResources } from '../resources.actions'

class Resources extends Component {
  state = {
    error: '',
    loading: true
  }

  async componentDidMount () {
    const { courseId, getResources } = this.props
    try {
      await promiseDispatch(getResources, { courseId })
    } catch (error) {
      console.log(error)
      this.setState({ error: 'Could not fetch data' })
    }
    this.setState({ loading: false })
  }

  render () {
    const { error, loading } = this.state
    const { courseId, resources } = this.props
    const resourcesForCourse = resources[courseId] || []

    if (error) return <p>Something went wrong... {error}</p>
    if (loading) return <p>Loading...</p>

    return (
      <CardDeck>
        {resourcesForCourse.map(item => (
          <Card key={item._id}>
            <CardBody>
              <CardTitle tag='h4'>{item.title}</CardTitle>
              <CardText>{item.description}</CardText>
              <CardLink href={item.link}>Link</CardLink>
            </CardBody>
          </Card>
        ))}
      </CardDeck>
    )
  }
}

const mapStateToProps = state => ({
  resources: selectResources(state)
})

const mapDispatchToProps = {
  getResources
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Resources)
