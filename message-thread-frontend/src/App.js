import React from 'react';
import MessageThreadList from './components/MessageThreadList';
import ErrorBoundary from './components/ErrorBoundary';

function App() {
  return (
    <div className="App">
      <ErrorBoundary>
        <MessageThreadList />
      </ErrorBoundary>
    </div>
  );
}

export default App;
