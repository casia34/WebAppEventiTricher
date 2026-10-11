import { useEffect, useState } from "react";


function App() {
  const Title = 'welcome to Reactivities'

  const [activity, setActivits] = useState([]);

  useEffect(() => {
    fetch('https://localhost:5001/api/activitisApi')
      .then(response => response.json())
      .then(data => setActivits(data))
  }, [])
  
  return (
      
    <div>
   <h3 className="ReactText" style={{ color: 'blueviolet' }}>{Title}</h3>
    <ul>
      {activity.map((act: activity) => (
        <li key={act.id}>{act.description}</li>
      ))}
    </ul>
    </div>
  )
}

export default App
