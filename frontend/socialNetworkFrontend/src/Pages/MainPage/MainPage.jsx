import React from 'react';
import styles from './MainPage.module.scss';
import Navigation from '../../Components/Navigation/Navigation';
import Aside from '../../Components/Aside/Aside';
import Story from '../../Components/Stories/Story.jsx'
import Post from '../../Components/Post/Post.jsx'

function MainPage() {
  return (
    <div className={styles.wrapper}>
        <div className={styles.stories}>
            <Story />
            <Story />
            <Story />
            <Story />
            <Story />
            <Story />
            <Story />
        </div>
        <div className={styles.posts}>
            <Post />
        </div>
        <Navigation />
        <Aside />
    </div>
  );
}
export default MainPage;
