import React, { Component } from 'react'
import {
  Card,
  CardHeader,
  CardFooter,
  CardBody,
  CardTitle,
  ListGroup,
  ListGroupItem,
  ListGroupItemHeading,
  ListGroupItemText
} from 'reactstrap'
import { connect } from 'react-redux'
import { CourseModal, LinkModal, ResourceModal } from '../components'
import { selectCourses, getCourses, postCourse } from '../courses'

class TeacherCourses extends Component {
  state = {
    error: '',
    loading: true
  }

  async componentDidMount () {
    const { getCourses } = this.props
    try {
      await getCourses()
    } catch (error) {
      console.log(error)
      this.setState({ error: 'Could not fetch data' })
    }
    this.setState({ loading: false })
  }

  render () {
    const { error, loading } = this.state
    const { courses } = this.props

    if (loading) {
      return (
        <p>Loading...</p>
      )
    }
    if (error) {
      return (
        <p>Something went wrong...</p>
      )
    }
    return (
      <Card>
        {/* {state.props.title} and so on to use fetched data  I GUESS :-? */}
        <CardHeader>Machine Learning</CardHeader>

        <CardBody>
          <CardTitle>Courses</CardTitle>
          <ListGroup>
            <ListGroupItem>
              <ListGroupItemHeading>Course 1</ListGroupItemHeading>
              <ListGroupItemText>
                Donec id elit non mi porta gravida at eget metus. Maecenas sed
                diam eget risus varius blandit.
              </ListGroupItemText>
            </ListGroupItem>
            <ListGroupItem>
              <ListGroupItemHeading>Course 2</ListGroupItemHeading>
              <ListGroupItemText>
                Donec id elit non mi porta gravida at eget metus. Maecenas sed
                diam eget risus varius blandit.
              </ListGroupItemText>
            </ListGroupItem>
            <ListGroupItem>
              <ListGroupItemHeading>Course 3</ListGroupItemHeading>
              <ListGroupItemText>
                Donec id elit non mi porta gravida at eget metus. Maecenas sed
                diam eget risus varius blandit.
              </ListGroupItemText>
              <ListGroup flush>
                <p>References:</p>
                <ListGroupItem tag='a' href='#'>
                  Dapibus ac facilisis in
                </ListGroupItem>
                <ListGroupItem tag='a' href='#'>
                  Morbi leo risus
                </ListGroupItem>
                <ListGroupItem tag='a' href='#'>
                  Porta ac consectetur ac
                </ListGroupItem>
                <ListGroupItem tag='a' href='#'>
                  Vestibulum at eros
                </ListGroupItem>
                <ListGroupItem>
                  {' '}
                  <LinkModal /> {' or '} <ResourceModal />{' '}
                </ListGroupItem>
              </ListGroup>
            </ListGroupItem>
          </ListGroup>
          <CourseModal />
        </CardBody>
        <CardFooter>Footer</CardFooter>
      </Card>
    )
  }
}

const mapStateToProps = state => ({
  courses: selectCourses(state)
})

const mapDispatchToProps = {
  getCourses,
  postCourse
}

export default connect(mapStateToProps, mapDispatchToProps)(TeacherCourses)
