import React, { useState } from 'react';
import styles from './Search.module.scss';
import { IoSearchSharp } from 'react-icons/io5';

function Search() {
  const [inputValue, setInputValue] = useState('');

  const handleInputChange = (e) => {
    setInputValue(e.target.value);
  };

  return (
    <div className={`${styles.wrapper} ${inputValue ? styles.focused : ''}`}>
      <IoSearchSharp style={{ color: 'gray', fontSize: '25px' }} />
      <input
        type="text"
        placeholder="Поиск в Brimo"
        value={inputValue}
        onChange={handleInputChange}
      />
    </div>
  );
}

export default Search;
