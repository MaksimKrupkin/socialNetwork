import React from 'react';
import styles from './MainPage.module.scss';
import NavItem from '../../Components/Navigation/Navigation';

function MainPage() {
  return (
    <div className={styles.wrapper}>
      <header className={styles.header}>
        <div className={styles.logo}>Brimo</div>
      </header>
      <Navigation />
    </div>
  );
}
export default MainPage;
