import React, { Component } from 'react'
import {
  Card,
  CardHeader,
  CardDeck,
  CardBody,
  CardTitle,
  CardText,
  ButtonGroup
} from 'reactstrap'
import { connect } from 'react-redux'

import { CourseModal, LinkModal, ResourceModal } from '../components'
import { promiseDispatch } from '../common'
import { selectCourses, getCourses } from '../courses'
import { Resources } from '../resources'

class TeacherCourses extends Component {
  state = {
    error: '',
    loading: true
  }

  async componentDidMount () {
    const { getCourses } = this.props
    try {
      await promiseDispatch(getCourses)
    } catch (error) {
      console.log(error)
      this.setState({ error: 'Could not fetch data' })
    }
    this.setState({ loading: false })
  }

  render () {
    const { error, loading } = this.state
    const { courses } = this.props

    if (error) return <p>Something went wrong... {error}</p>
    if (loading) return <p>Loading...</p>

    return (
      <Card>
        <CardHeader>
          <CardTitle tag='h1'>Courses</CardTitle>
        </CardHeader>

        <CardBody>
          <CardDeck>
            {courses.map(item => (
              <Card key={item._id}>
                <CardHeader>
                  <CardTitle tag='h2'>{item.title}</CardTitle>
                </CardHeader>
                <CardBody>
                  <CardTitle tag='h3'>Description</CardTitle>
                  <CardText>{item.description}</CardText>
                  <CardTitle tag='h3'>Resources</CardTitle>
                  <Resources courseId={item._id} />
                  <CardTitle tag='h3'>Controls</CardTitle>
                  <ButtonGroup>
                    <LinkModal courseId={item._id} />
                    <ResourceModal courseId={item._id} />
                  </ButtonGroup>
                </CardBody>
              </Card>
            ))}
          </CardDeck>
          <CourseModal />
        </CardBody>
      </Card>
    )
  }
}

const mapStateToProps = state => ({
  courses: selectCourses(state)
})

const mapDispatchToProps = {
  getCourses
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(TeacherCourses)
