import React, { Fragment } from 'react'
import { Route } from 'react-router'
// import ProtectedRoute from './common/components/ProtectedRoute'
import { Home, TeacherCourses } from './screens'

export default () => (
  <Fragment>
    <Route path='/teacher_courses' component={TeacherCourses} />
    <Route exact path='/' component={Home} />
    {/* <ProtectedRoute exact path="/student" component={StudentHomePage} /> */}
  </Fragment>
)
