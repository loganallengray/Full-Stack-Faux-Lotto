import React from 'react';
import './App.css';
import { Button } from 'reactstrap';
import Header from './components/nav/Header';
import ApplicationView from './components/ApplicationView';
import HeaderUnauth from './components/nav/HeaderUnauth';
import ApplicationViewUnauth from './components/ApplicationViewUnauth';
import { BrowserRouter } from 'react-router-dom';

// Returns Header at the top always
// Returns Applications Views, where all the available views are contained.

// If user is not logged in, will return unauthentificated versions of both.

const App = () => {
  return (
    <BrowserRouter>
      {true ? (
        <>
          <Header />
          <ApplicationView />
        </>
      ) : (
        <>
          <HeaderUnauth />
          <ApplicationViewUnauth />
        </>
      )}
    </BrowserRouter>
  );
}

export default App;
