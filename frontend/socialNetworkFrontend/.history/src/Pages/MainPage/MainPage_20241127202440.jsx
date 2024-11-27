import React from 'react';
import styles from './MainPage.module.scss';
import Navigation from '../../Components/Navigation/Navigation';

function MainPage() {
  return (
    <div className={styles.wrapper}>
      <Navigation />
    </div>
  );
}
export default MainPage;
