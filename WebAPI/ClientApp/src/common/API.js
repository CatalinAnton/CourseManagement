export default (() => {
  const headers = {
    'Authorization': '',
    'Content-Type': 'application/json'
  }

  const Fetch = (method, location, body = undefined) => {
    const response = fetch(
      location,
      {
        method,
        headers,
        ...(body && { body }),
        mode: 'no-cors',
        credentials: 'include'
      }
    )

    return {
      toText: () => response.then(async data => ({ status: data.status, statusText: data.statusText, data: await data.text() })),
      toJson: () => response.then(async data => ({ status: data.status, statusText: data.statusText, data: await data.json() })),
      toBlob: () => response.then(async data => ({ status: data.status, statusText: data.statusText, data: await data.blob() }))
    }
  }

  const GET = (location) => Fetch('GET', location)

  const POST = (location, body) => Fetch('POST', location, body)

  const PUT = (location, body) => Fetch('PUT', location, body)

  const PATCH = (location, body) => Fetch('PATCH', location, body)

  const setHeader = (header, value) => {
    headers[header] = value
  }

  return {
    GET,
    POST,
    PUT,
    PATCH,
    setHeader
  }
})()
