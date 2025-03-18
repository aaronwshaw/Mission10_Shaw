import Heading from './Heading';
import BowlerList from './BowlerList'; // Import the new BowlerList component

// Main application component
const App = () => {
  return (
    <>
      {/* Display the heading */}
      <Heading />
      {/* Display the bowler list, which handles fetching and filtering */}
      <BowlerList />
    </>
  );
};

export default App;
