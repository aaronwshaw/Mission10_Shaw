import Heading from './Heading';
import BowlerList from './BowlerList'; // Import the new BowlerList component

// Main application component
const App = () => {
  return (
    <div className="container mx-auto p-4">
      {/* Display the heading */}
      <Heading />
      {/* Display the bowler list, which handles fetching and filtering */}
      <BowlerList />
    </div>
  );
};

export default App;
