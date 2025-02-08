/** 静态数据库 */
export class DBManager {
    private static dbMap: Map<string, Map<number | string, any>> = new Map();

    // 获取数据库
    public static getDB<K extends keyof DBManagerTypeMapping>(dbName: K): Map<number | string, DBManagerTypeMapping[K]> | undefined {
        return this.dbMap.get(dbName);
    }

    // 获取数据库
    public static getDb(dbName: string): Map<number | string, any> | undefined {
        return this.dbMap.get(dbName);
    }

// ==================== 数据库GET方法 ====================

    public static getDbConstNumber(key: string): DbConstNumber | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbConstNumber");
    return db ? db.get(key) : undefined;
    }

    public static getDbConstArray(key: string): DbConstArray | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbConstArray");
    return db ? db.get(key) : undefined;
    }

    public static getDbConstRes(key: string): DbConstRes | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbConstRes");
    return db ? db.get(key) : undefined;
    }

    public static getDbChannel(id: number): DbChannel | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbChannel");
    return db ? db.get(id) : undefined;
    }

    public static getBuffData(id: number): BuffData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("BuffData");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowthData(id: number): DBGrowthData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowthData");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowthUpgradeCount(id: number): DBGrowthUpgradeCount | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowthUpgradeCount");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowthCostData(id: number): DBGrowthCostData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowthCostData");
    return db ? db.get(id) : undefined;
    }

    public static getDBStatueAdvance(id: number): DBStatueAdvance | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBStatueAdvance");
    return db ? db.get(id) : undefined;
    }

    public static getDBStatueData(id: number): DBStatueData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBStatueData");
    return db ? db.get(id) : undefined;
    }

    public static getMazeData(id: number): MazeData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("MazeData");
    return db ? db.get(id) : undefined;
    }

    public static getDBUnlockFunc(id: number): DBUnlockFunc | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBUnlockFunc");
    return db ? db.get(id) : undefined;
    }

    public static getEnemyModuleData(id: number): EnemyModuleData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("EnemyModuleData");
    return db ? db.get(id) : undefined;
    }

    public static getRankData(id: number): RankData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("RankData");
    return db ? db.get(id) : undefined;
    }

    public static getStageData(id: number): StageData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("StageData");
    return db ? db.get(id) : undefined;
    }

    public static getCollectRankData(id: number): CollectRankData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("CollectRankData");
    return db ? db.get(id) : undefined;
    }

    public static getDbPay(id: number): DbPay | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbPay");
    return db ? db.get(id) : undefined;
    }

    public static getDbPrice(id: number): DbPrice | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbPrice");
    return db ? db.get(id) : undefined;
    }

    public static getBuildingData(id: number): BuildingData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("BuildingData");
    return db ? db.get(id) : undefined;
    }

    public static getBuildingTowerData(id: number): BuildingTowerData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("BuildingTowerData");
    return db ? db.get(id) : undefined;
    }

    public static getBuildingMeatData(id: number): BuildingMeatData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("BuildingMeatData");
    return db ? db.get(id) : undefined;
    }

    public static getBuildingStoneData(id: number): BuildingStoneData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("BuildingStoneData");
    return db ? db.get(id) : undefined;
    }

    public static getBuildingRefineData(id: number): BuildingRefineData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("BuildingRefineData");
    return db ? db.get(id) : undefined;
    }

    public static getChestDropData(id: number): ChestDropData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("ChestDropData");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth0Value(id: number): DBGrowth0Value | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth0Value");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth0Cost(id: number): DBGrowth0Cost | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth0Cost");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth1Value(id: number): DBGrowth1Value | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth1Value");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth1Cost(id: number): DBGrowth1Cost | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth1Cost");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth2Value(id: number): DBGrowth2Value | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth2Value");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth2Cost(id: number): DBGrowth2Cost | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth2Cost");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth3Value(id: number): DBGrowth3Value | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth3Value");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth3Cost(id: number): DBGrowth3Cost | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth3Cost");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth4Value(id: number): DBGrowth4Value | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth4Value");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth4Cost(id: number): DBGrowth4Cost | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth4Cost");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth5Value(id: number): DBGrowth5Value | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth5Value");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth5Cost(id: number): DBGrowth5Cost | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth5Cost");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth6Value(id: number): DBGrowth6Value | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth6Value");
    return db ? db.get(id) : undefined;
    }

    public static getDBGrowth6Cost(id: number): DBGrowth6Cost | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBGrowth6Cost");
    return db ? db.get(id) : undefined;
    }

    public static getMissionConditionData(id: number): MissionConditionData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("MissionConditionData");
    return db ? db.get(id) : undefined;
    }

    public static getMissionMainData(id: number): MissionMainData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("MissionMainData");
    return db ? db.get(id) : undefined;
    }

    public static getMissionNormalData(id: number): MissionNormalData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("MissionNormalData");
    return db ? db.get(id) : undefined;
    }

    public static getMissionProfileData(id: number): MissionProfileData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("MissionProfileData");
    return db ? db.get(id) : undefined;
    }

    public static getGoodsRandomData(id: number): GoodsRandomData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("GoodsRandomData");
    return db ? db.get(id) : undefined;
    }

    public static getGoodsVarietyData(id: number): GoodsVarietyData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("GoodsVarietyData");
    return db ? db.get(id) : undefined;
    }

    public static getPackageData(id: number): PackageData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("PackageData");
    return db ? db.get(id) : undefined;
    }

    public static getDiamondData(id: number): DiamondData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DiamondData");
    return db ? db.get(id) : undefined;
    }

    public static getGoodsRandomDetailData(id: number): GoodsRandomDetailData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("GoodsRandomDetailData");
    return db ? db.get(id) : undefined;
    }

    public static getDBHeroProperty(key: number): DBHeroProperty | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBHeroProperty");
    return db ? db.get(key) : undefined;
    }

    public static getDBAssembleProperty(key: number): DBAssembleProperty | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBAssembleProperty");
    return db ? db.get(key) : undefined;
    }

    public static getDBPlayerProperty(key: number): DBPlayerProperty | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBPlayerProperty");
    return db ? db.get(key) : undefined;
    }

    public static getDBRaceProperty(key: number): DBRaceProperty | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBRaceProperty");
    return db ? db.get(key) : undefined;
    }

    public static getDBExclusiveProperty(key: number): DBExclusiveProperty | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBExclusiveProperty");
    return db ? db.get(key) : undefined;
    }

    public static getDBBondProperty(key: number): DBBondProperty | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBBondProperty");
    return db ? db.get(key) : undefined;
    }

    public static getDBPerk(id: number): DBPerk | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBPerk");
    return db ? db.get(id) : undefined;
    }

    public static getDBLevelPass(id: number): DBLevelPass | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBLevelPass");
    return db ? db.get(id) : undefined;
    }

    public static getDBMainPass(id: number): DBMainPass | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBMainPass");
    return db ? db.get(id) : undefined;
    }

    public static getCollectHeroData(id: number): CollectHeroData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("CollectHeroData");
    return db ? db.get(id) : undefined;
    }

    public static getDBMedal(id: number): DBMedal | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBMedal");
    return db ? db.get(id) : undefined;
    }

    public static getSkillData(id: number): SkillData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("SkillData");
    return db ? db.get(id) : undefined;
    }

    public static getDBHeroEffect(id: number): DBHeroEffect | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBHeroEffect");
    return db ? db.get(id) : undefined;
    }

    public static getDBHeroExp(id: number): DBHeroExp | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBHeroExp");
    return db ? db.get(id) : undefined;
    }

    public static getDBHeroUpgradeData(id: number): DBHeroUpgradeData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBHeroUpgradeData");
    return db ? db.get(id) : undefined;
    }

    public static getDBHeroRefines(id: number): DBHeroRefines | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBHeroRefines");
    return db ? db.get(id) : undefined;
    }

    public static getBulletData(id: number): BulletData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("BulletData");
    return db ? db.get(id) : undefined;
    }

    public static getDBNormalSummon(id: number): DBNormalSummon | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBNormalSummon");
    return db ? db.get(id) : undefined;
    }

    public static getDbBlessing(id: number): DbBlessing | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbBlessing");
    return db ? db.get(id) : undefined;
    }

    public static getDbBlessingSub(id: number): DbBlessingSub | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DbBlessingSub");
    return db ? db.get(id) : undefined;
    }

    public static getDBEquip(id: number): DBEquip | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBEquip");
    return db ? db.get(id) : undefined;
    }

    public static getDBSetEquip(id: number): DBSetEquip | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBSetEquip");
    return db ? db.get(id) : undefined;
    }

    public static getDBEquipUpgrade(id: number): DBEquipUpgrade | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBEquipUpgrade");
    return db ? db.get(id) : undefined;
    }

    public static getDBEquipDismantle(id: number): DBEquipDismantle | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DBEquipDismantle");
    return db ? db.get(id) : undefined;
    }

    public static getDropData(id: number): DropData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DropData");
    return db ? db.get(id) : undefined;
    }

    public static getCurrencyData(id: number): CurrencyData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("CurrencyData");
    return db ? db.get(id) : undefined;
    }

    public static getDailyCurrencyData(id: number): DailyCurrencyData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("DailyCurrencyData");
    return db ? db.get(id) : undefined;
    }

    public static getHeroData(id: number): HeroData | undefined {
    const db: Map<number | string, any> = this.dbMap.get("HeroData");
    return db ? db.get(id) : undefined;
    }

    public static getdict_main(key: string): dict_main | undefined {
    const db: Map<number | string, any> = this.dbMap.get("dict_main");
    return db ? db.get(key) : undefined;
    }

    public static getdict_icon(key: string): dict_icon | undefined {
    const db: Map<number | string, any> = this.dbMap.get("dict_icon");
    return db ? db.get(key) : undefined;
    }

    /** 初始化数据库 */
    private static _initDatabase(_json: any, jsonKey: string): boolean {
        interface IExportDB {
            //数据库KEY
            sheetKeys: string[],
            //数据库数据
            sheetData: object[],
        }

        const db: IExportDB = _json[jsonKey];
        if (!db) {
            console.error('db is null ! ', jsonKey);
            return false;
        }

        const dbData: Map<number | string, any> = new Map();
        for (const data of db.sheetData) {
            let keys: string[] = [];
            Object.entries(data).forEach(([key, value]: [string, any]) => {
                if (db.sheetKeys.includes(key)) keys.push(value);
            });
            dbData.set(keys.length === 1 ? keys[0] : keys.join("_"), data);
        }
        this.dbMap.set(jsonKey, dbData);
        return true;
    }

    /** 初始化数据库 */
    public static initDbWithIgnore(_json: any): boolean {
        const arrJsonKeys: string[] = Object.keys(_json);
        for (const jsonKey of arrJsonKeys) {
            if (!DBManager._initDatabase(_json, jsonKey)) {
                return false;
            }
        }
        return true;
    }
}

// ==================== 自定义接口 ====================

export interface IAdConfig {
    // 
    id: string
    // 
    width: number
    // 
    height: number
    // 
    originX: number
    // 
    originY: number
    // 
    anchorX: number
    // 
    anchorY: number
    // 
    offsetX: number
    // 
    offsetY: number
    // 
    interval: number
}

export interface IStyle {
    // 
    width: number
    // 
    height: number
    // 
    originX: number
    // 
    originY: number
    // 
    anchorX: number
    // 
    anchorY: number
    // 
    offsetX: number
    // 
    offsetY: number
}

export interface IRecord {
    // 
    title: string
    // 
    topic: Array<string>
}

export interface IProperty {
    // 
    type: number
    // 
    id: number
    // 
    value: number
}

export interface IRes {
    // 
    type: number
    // 
    id: number
    // 
    count: number
}

// ==================== 数据表接口 ====================

export interface DbConstNumber {
    // 编号
    key: string
    // 值
    value: number
}

export interface DbConstArray {
    // 编号
    key: string
    // 值
    value: Array<number>
}

export interface DbConstRes {
    // 编号
    key: string
    // 值
    value: Array<IRes>
}

export interface DbChannel {
    // 编号
    id: number
    // 平台
    channel: number
    // AppId
    appId: string
    // AppKey
    appKey: string
    // 字典前缀
    dictKeyPrefix: string
    // OfferId
    offerId: string
    // 内购开关
    isIAPOn: number
    // 价格类型
    priceId: number
    // 测试支付
    payTest: boolean
    // 支付类型
    payType: number
    // 游戏币价格
    coinPrice: number
    // 服务器地址
    serverAddress: string
    // 策略地址
    address: string
    // 区服
    serverArea: string
    // 聊天服务器
    chatServer: string
    // 游戏版本
    gameVer: number
    // 版本号
    version: string
    // 横幅广告
    banner: IAdConfig
    // 激励视频广告
    reward: Array<string>
    // 插屏广告
    inter: string
    // 微信手Q定制广告
    custom: Array<IAdConfig>
    // 更多游戏广告
    gamePortal: IAdConfig
    // 游戏圈（微信）
    gameClub: IStyle
    // 客服（抖音）
    service: IStyle
    // 抖音录屏
    record: IRecord
}

export interface BuffData {
    // id
    id: number
    // 类型
    type: number
    // 叠加上限
    max: number
    // 触发几率
    per: number
    // 属性
    props: Array<number>
    // 值
    values: Array<number>
    // 成长
    valuesGrow: Array<number>
    // 属性
    duration: number
    // 高度
    height: number
    // 可否去除
    remove: boolean
    // 特效预制体
    prefab: string
}

export interface DBGrowthData {
    // id
    id: number
    // 属性类型
    propertType: IProperty
    // 等级上限
    lvCap: number
    // 解锁条件
    funcId: number
    // 初始属性
    initProperty: number
}

export interface DBGrowthUpgradeCount {
    // id
    id: number
    // 次数
    count: number
    // 解锁功能id
    funcId: number
}

export interface DBGrowthCostData {
    // id
    id: number
    // 起始消耗
    startCost: string
    // 成长消耗
    growthCost: string
}

export interface DBStatueAdvance {
    // id
    id: number
    // 等级上限
    lvCap: number
    // 属性id
    property: IProperty
    // 消耗
    cost: IRes
}

export interface DBStatueData {
    // id
    id: number
    // 皮肤名称
    name: string
    // 稀有度
    rare: number
    // 装备属性
    equippedProperties: Array<IProperty>
    // 持有效果
    effect: IProperty
    // 获取途径
    acquisitionMethod: number
    // 价格
    price: string
}

export interface MazeData {
    // id
    id: number
    // tiled名字
    name: string
    // 颜色
    color: string
    // 背景板
    bg: string
    // 抬头板
    title: string
    // 消耗货币Id
    costId: number
    // 产出货币Id
    prodId: number
    // 视频货币
    ad: number
    // 解锁
    unlock: number
    // tiled名字
    map: string
    // 怪物数量
    emyCount: number
    // 怪物数组
    emyList: Array<number>
    // 倒计时
    time: number
    // 脚本
    script: string
    // 奖励
    reward: number
}

export interface DBUnlockFunc {
    // id
    id: number
    // 解锁类型
    type: number
    // 解锁参数
    params: Array<number>
}

export interface EnemyModuleData {
    // id
    id: number
    // 类型
    type: number
    // 速度
    speed: number
    // 模型
    model: string
    // 技能数组
    skills: Array<number>
    // 抗性
    resist: Array<number>
    // 影子
    shadow: string
    // ai脚本
    aiScript: string
    // 中心Y
    centerY: number
    // 血条Y
    hpY: number
    // 缩放
    scale: number
}

export interface RankData {
    // id
    id: number
    // tiled名字
    map: string
    // 类型
    type: number
    // 怪物数量
    emyCount: number
    // 怪物数组
    emyList: Array<number>
    // 脚本
    script: string
    // 血量
    hp: string
}

export interface StageData {
    // id
    id: number
    // 基础值
    base1: string
    // 成长值
    grow1: string
    // 基础值
    base2: string
    // 成长值
    grow2: string
    // 基础值
    base3: number
    // 成长值
    grow3: number
    // 图片
    icon: string
    // 关卡组Id
    rankId: number
}

export interface CollectRankData {
    // id
    id: number
    // 关卡ID
    rank: number
    // 杀怪数
    count: number
    // 属性ID
    property: number
    // 奖励
    reward: IRes
}

export interface DbPay {
    // 编号
    id: number
    // 产品id
    prodId: string
    // 名字
    name: string
    // 资源1
    reward1: Array<IRes>
    // 资源2
    reward2: Array<IRes>
    // 资源2
    reward3: Array<IRes>
    // 前置
    perp: number
    // 首充双倍
    firstDouble: boolean
    // 值
    price: number
    // 限购类型
    limitType: number
    // 限购次数
    limitCount: number
    // 售出状态
    soldStatus: number
}

export interface DbPrice {
    // 编号
    id: number
    // 值
    cny: number
    // 值
    usd: number
}

export interface BuildingData {
    // id
    id: number
    // 名字
    name: string
    // 图片
    icon: string
    // 资源图标
    iconRes: string
    // 挂机资源
    afkRes: number
    // 英雄解锁等级
    heroes: Array<number>
    // 解锁条件
    unlock: number
    // 建造价格
    price: number
    // 建造时间
    time: number
}

export interface BuildingTowerData {
    // id
    id: number
    // 升级价格
    price: number
    // 升级时间
    time: number
    // 加成数值
    add: number
}

export interface BuildingMeatData {
    // id
    id: number
    // 升级价格
    price: number
    // 升级时间
    time: number
    // 产量
    count: number
    // 最大
    max: number
}

export interface BuildingStoneData {
    // id
    id: number
    // 升级价格
    price: number
    // 升级时间
    time: number
    // 产量
    count: number
    // 最大
    max: number
}

export interface BuildingRefineData {
    // id
    id: number
    // 升级价格
    price: number
    // 升级时间
    time: number
    // 产量
    count: number
    // 最大
    max: number
}

export interface ChestDropData {
    // id
    id: number
    // 资源
    res: IRes
    // 权重
    weight: number
    // 组
    group: number
}

export interface DBGrowth0Value {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth0Cost {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth1Value {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth1Cost {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth2Value {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth2Cost {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth3Value {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth3Cost {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth4Value {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth4Cost {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth5Value {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth5Cost {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth6Value {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface DBGrowth6Cost {
    // id
    id: number
    // 最小
    min: number
    // 最大
    max: number
    // 基础值
    base: string
    // 成长值
    grow: string
}

export interface MissionConditionData {
    // id
    id: number
    // 描述
    desc: string
}

export interface MissionMainData {
    // id
    id: number
    // 条件
    condition: number
    // 达成数量
    max: number
    // 奖励
    reward: IRes
}

export interface MissionNormalData {
    // id
    id: number
    // 类型
    type: number
    // 条件
    condition: number
    // 达成数量
    max: number
    // 奖励
    reward: IRes
}

export interface MissionProfileData {
    // id
    id: number
    // 名字
    name: string
    // 类型
    type: number
    // 条件
    condition: number
    // 参数
    param: number
    // 达成数量
    max: number
    // 属性
    property: IProperty
    // 图标名字
    icon: string
}

export interface GoodsRandomData {
    // id
    id: number
    // 掉落
    drop: number
    // 底板颜色
    color: number
    // 限购类型
    limitType: number
    // 限购次数
    limitCount: number
}

export interface GoodsVarietyData {
    // id
    id: number
    // 底板颜色
    color: number
    // 商品
    goods: IRes
    // 价格
    price: IRes
    // 限购类型
    limitType: number
    // 限购次数
    limitCount: number
}

export interface PackageData {
    // id
    id: number
    // 计费id
    payId: Array<number>
    // 页签
    page: number
    // 底板颜色
    color: number
    // 图标
    icon: string
    // 价值系数
    valueScale: number
    // 商品格子
    grid: Array<number>
    // 标签
    tag: Array<number>
}

export interface DiamondData {
    // id
    id: number
    // 计费id
    payId: number
    // 底板颜色
    color: number
    // 图标
    icon: string
}

export interface GoodsRandomDetailData {
    // id
    id: number
    // 资源
    res: IRes
    // 掉落
    dropId: number
    // 价格
    cost: IRes
    // 原价
    costOri: number
}

export interface DBHeroProperty {
    // key
    key: number
    // 百分比
    percentage: boolean
    // 初始值
    init: number
    // 单位
    unit: string
}

export interface DBAssembleProperty {
    // key
    key: number
    // 百分比
    percentage: boolean
    // 初始值
    init: number
    // 单位
    unit: string
}

export interface DBPlayerProperty {
    // key
    key: number
    // 百分比
    percentage: boolean
    // 初始值
    init: number
    // 单位
    unit: string
}

export interface DBRaceProperty {
    // key
    key: number
    // 百分比
    percentage: boolean
    // 初始值
    init: number
    // 单位
    unit: string
    // 参数 [种族，英雄属性id]
    params: Array<number>
}

export interface DBExclusiveProperty {
    // key
    key: number
    // 百分比
    percentage: boolean
    // 初始值
    init: number
    // 单位
    unit: string
}

export interface DBBondProperty {
    // key
    key: number
    // 百分比
    percentage: boolean
    // 初始值
    init: number
    // 单位
    unit: string
    // 参数 [英雄id]
    heroParam: Array<number>
    // 参数 [属性id]
    propertiesParam: Array<number>
}

export interface DBPerk {
    // id
    id: number
    // 父节点
    parentIds: Array<number>
    // 等级上限
    lvCap: number
    // 属性id
    property: IProperty
    // 消耗
    cost: IRes
}

export interface DBLevelPass {
    // id
    id: number
    // 进度
    progress: Array<number>
    // 免费奖励
    freeReward: Array<IRes>
    // 进阶奖励
    advanceReward: Array<IRes>
    // 支付
    pay: number
}

export interface DBMainPass {
    // id
    id: number
    // 进度
    progress: Array<number>
    // 免费奖励
    freeReward: Array<IRes>
    // 进阶奖励
    advanceReward: Array<IRes>
    // 支付
    pay: number
}

export interface CollectHeroData {
    // id
    id: number
    // 名字
    name: string
    // 英雄组
    heroes: Array<number>
    // 等级上限
    lvMax: number
    // 属性
    property: IProperty
    // 成长值
    growth: number
}

export interface DBMedal {
    // id
    id: number
    // 属性id
    property: Array<IProperty>
    // 等级上限
    lvCap: number
}

export interface SkillData {
    // id
    id: number
    // 介绍
    desc: string
    // 介绍值
    descValue: Array<number>
    // 名字
    name: string
    // 图标
    icon: string
    // 类型
    type: number
    // 召唤id
    sId: number
    // 射程
    range: number
    // 瞄准类型
    aimType: number
    // 系数
    per: number
    // 系数成长
    perGrow: number
    // 技能cd
    cd: number
    // 自己buff
    buff: Array<number>
    // 子弹类型
    bltType: number
    // 子弹id
    bulletId: Array<number>
    // 额外技能
    exSkill: number
    // 每发数量
    bltNum: number
    // 连斩几率
    comboPer: number
    // 弹夹数
    shot: number
    // 每发cd
    shotCD: number
    // 子弹夹角
    bltAngle: number
    // 夹角递增
    addAngle: number
    // 发射高度
    shootH: number
    // cd清除
    clearCD: number
}

export interface DBHeroEffect {
    // 稀有度
    id: number
    // 基础持有效果
    baseEffect: number
    // 持有效果每级加成
    effectBouns: number
}

export interface DBHeroExp {
    // 稀有度
    id: number
    // 基础经验值
    baseExp: number
    // 基础差值
    baseDiff: number
    // 阶跃增加经验值
    addExp: number
}

export interface DBHeroUpgradeData {
    // id
    id: number
    // 英雄升星消耗碎片数量
    starCost: number
}

export interface DBHeroRefines {
    // id
    id: number
    // 稀有度
    rare: number
    // 属性
    property: IProperty
}

export interface BulletData {
    // id
    id: number
    // 速度
    speed: number
    // 角速度
    aSpeed: number
    // 生命周期
    life: number
    // 移动类型
    moveType: number
    // 瞄准类型
    aimType: number
    // 伤害系数
    per: number
    // buff额外伤害
    exPer: Array<number>
    // 模型
    model: string
    // 穿刺
    through: number
    // 打击特效
    hitEff: string
    // 打击音效
    hitSe: string
    // buffId
    buff: Array<number>
    // 子母弹id
    subId: number
    // 母弹发射间隔
    subInv: number
    // 子母弹延时
    subDelay: number
    // 图层
    dl: number
    // 中断
    break: boolean
    // 自动旋转
    rotate: boolean
    // 功能
    func: Array<number>
}

export interface DBNormalSummon {
    // id
    id: number
    // 召唤类型
    type: DBSummonTypeEnum;
    // 掉落id
    dropId: number
}

export interface DbBlessing {
    // id
    id: number
    // 攻击成长
    atkGrow: number
    // 生命成长
    hpGrow: number
    // 经验上限
    expMax: number
    // 等级上限
    lvMax: number
}

export interface DbBlessingSub {
    // id
    id: number
    // 属性id
    property: IProperty
    // 成长
    grow: number
    // 经验上限
    expMax: number
    // 等级上限
    lvMax: number
}

export interface DBEquip {
    // id
    id: number
    // 套装id
    setId: number
    // 稀有度
    rare: number
    // 装备类型
    type: number
    // 属性
    properties: Array<IProperty>
}

export interface DBSetEquip {
    // id
    id: number
    // 三件套属性
    threePieceSet: Array<IProperty>
    // 五件套属性
    fivePieceSet: Array<IProperty>
}

export interface DBEquipUpgrade {
    // id
    id: number
    // 基础消耗
    baseCost: number
    // 消耗
    cost: number
}

export interface DBEquipDismantle {
    // id
    id: number
    // 分解材料
    materials: IRes
}

export interface DropData {
    // id
    id: number
    // 掉落类型
    type: number
    // 资源类型
    resType: number
    // 资源Id数组
    resId: Array<number>
    // 0几率|1权重|2数量
    per: Array<number>
}

export interface CurrencyData {
    // id
    id: number
    // 名字
    name: string
    // 图标
    icon: string
    // 介绍
    desc: string
    // 稀有度
    rare: number
    // 大数字
    isBig: boolean
    // 包裹显示
    visible: boolean
    // 钻石价格
    price: number
    // 是否可使用
    useable: boolean
    // 物品最低使用数量
    minUsageCount: number
    // 路由
    route: string
}

export interface DailyCurrencyData {
    // 货币id
    id: number
    // 回复数量
    recover: number
    // 上限
    limit: number
}

export interface HeroData {
    // id
    id: number
    // 名字
    name: string
    // 英雄类型
    heroType: number
    // 种族
    race: Array<number>
    // 职业类型
    occ: number
    // 品质
    rare: number
    // 技能1数组
    skills: Array<number>
    // 模型
    model: string
    // 图标
    icon: string
    // 脚本
    script: string
    // 基础攻击
    baseAtk: number
    // 基础生命
    baseHp: number
    // 基础攻速
    baseAtkRate: number
    // 基础移速
    baseMoveSpeed: number
    // 价格
    price: number
    // 存档默认英雄
    init: boolean
    // 五星属性
    fiveStarProp: IProperty
    // 十星技能
    tenStarSkill: number
    // 守护之塔
    townProp: IProperty
    // 成长
    townPropGrow: number
    // 专属洗练属性
    refines: Array<number>
}

export interface dict_main {
    // 编号
    key: string
    // 简体中文
    value_cn: string
    // 繁体中文
    value_hk: string
    // 英文
    value_en: string
    // 是否分渠道
    channel: number
}

export interface dict_icon {
    // 编号
    key: string
    // 简体中文
    value_cn: string
    // 繁体中文
    value_hk: string
    // 英文
    value_en: string
    // 是否分渠道
    channel: number
}

// ==================== 数据表类型映射 ====================

export type DBManagerTypeMapping = {
    DbConstNumber: DbConstNumber
    DbConstArray: DbConstArray
    DbConstRes: DbConstRes
    DbChannel: DbChannel
    BuffData: BuffData
    DBGrowthData: DBGrowthData
    DBGrowthUpgradeCount: DBGrowthUpgradeCount
    DBGrowthCostData: DBGrowthCostData
    DBStatueAdvance: DBStatueAdvance
    DBStatueData: DBStatueData
    MazeData: MazeData
    DBUnlockFunc: DBUnlockFunc
    EnemyModuleData: EnemyModuleData
    RankData: RankData
    StageData: StageData
    CollectRankData: CollectRankData
    DbPay: DbPay
    DbPrice: DbPrice
    BuildingData: BuildingData
    BuildingTowerData: BuildingTowerData
    BuildingMeatData: BuildingMeatData
    BuildingStoneData: BuildingStoneData
    BuildingRefineData: BuildingRefineData
    ChestDropData: ChestDropData
    DBGrowth0Value: DBGrowth0Value
    DBGrowth0Cost: DBGrowth0Cost
    DBGrowth1Value: DBGrowth1Value
    DBGrowth1Cost: DBGrowth1Cost
    DBGrowth2Value: DBGrowth2Value
    DBGrowth2Cost: DBGrowth2Cost
    DBGrowth3Value: DBGrowth3Value
    DBGrowth3Cost: DBGrowth3Cost
    DBGrowth4Value: DBGrowth4Value
    DBGrowth4Cost: DBGrowth4Cost
    DBGrowth5Value: DBGrowth5Value
    DBGrowth5Cost: DBGrowth5Cost
    DBGrowth6Value: DBGrowth6Value
    DBGrowth6Cost: DBGrowth6Cost
    MissionConditionData: MissionConditionData
    MissionMainData: MissionMainData
    MissionNormalData: MissionNormalData
    MissionProfileData: MissionProfileData
    GoodsRandomData: GoodsRandomData
    GoodsVarietyData: GoodsVarietyData
    PackageData: PackageData
    DiamondData: DiamondData
    GoodsRandomDetailData: GoodsRandomDetailData
    DBHeroProperty: DBHeroProperty
    DBAssembleProperty: DBAssembleProperty
    DBPlayerProperty: DBPlayerProperty
    DBRaceProperty: DBRaceProperty
    DBExclusiveProperty: DBExclusiveProperty
    DBBondProperty: DBBondProperty
    DBPerk: DBPerk
    DBLevelPass: DBLevelPass
    DBMainPass: DBMainPass
    CollectHeroData: CollectHeroData
    DBMedal: DBMedal
    SkillData: SkillData
    DBHeroEffect: DBHeroEffect
    DBHeroExp: DBHeroExp
    DBHeroUpgradeData: DBHeroUpgradeData
    DBHeroRefines: DBHeroRefines
    BulletData: BulletData
    DBNormalSummon: DBNormalSummon
    DbBlessing: DbBlessing
    DbBlessingSub: DbBlessingSub
    DBEquip: DBEquip
    DBSetEquip: DBSetEquip
    DBEquipUpgrade: DBEquipUpgrade
    DBEquipDismantle: DBEquipDismantle
    DropData: DropData
    CurrencyData: CurrencyData
    DailyCurrencyData: DailyCurrencyData
    HeroData: HeroData
    dict_main: dict_main
    dict_icon: dict_icon
}

// ==================== 数据表字面量枚举 ====================

export const enum DBManagerEnum {
    DbConstNumber = "DbConstNumber",
    DbConstArray = "DbConstArray",
    DbConstRes = "DbConstRes",
    DbChannel = "DbChannel",
    BuffData = "BuffData",
    DBGrowthData = "DBGrowthData",
    DBGrowthUpgradeCount = "DBGrowthUpgradeCount",
    DBGrowthCostData = "DBGrowthCostData",
    DBStatueAdvance = "DBStatueAdvance",
    DBStatueData = "DBStatueData",
    MazeData = "MazeData",
    DBUnlockFunc = "DBUnlockFunc",
    EnemyModuleData = "EnemyModuleData",
    RankData = "RankData",
    StageData = "StageData",
    CollectRankData = "CollectRankData",
    DbPay = "DbPay",
    DbPrice = "DbPrice",
    BuildingData = "BuildingData",
    BuildingTowerData = "BuildingTowerData",
    BuildingMeatData = "BuildingMeatData",
    BuildingStoneData = "BuildingStoneData",
    BuildingRefineData = "BuildingRefineData",
    ChestDropData = "ChestDropData",
    DBGrowth0Value = "DBGrowth0Value",
    DBGrowth0Cost = "DBGrowth0Cost",
    DBGrowth1Value = "DBGrowth1Value",
    DBGrowth1Cost = "DBGrowth1Cost",
    DBGrowth2Value = "DBGrowth2Value",
    DBGrowth2Cost = "DBGrowth2Cost",
    DBGrowth3Value = "DBGrowth3Value",
    DBGrowth3Cost = "DBGrowth3Cost",
    DBGrowth4Value = "DBGrowth4Value",
    DBGrowth4Cost = "DBGrowth4Cost",
    DBGrowth5Value = "DBGrowth5Value",
    DBGrowth5Cost = "DBGrowth5Cost",
    DBGrowth6Value = "DBGrowth6Value",
    DBGrowth6Cost = "DBGrowth6Cost",
    MissionConditionData = "MissionConditionData",
    MissionMainData = "MissionMainData",
    MissionNormalData = "MissionNormalData",
    MissionProfileData = "MissionProfileData",
    GoodsRandomData = "GoodsRandomData",
    GoodsVarietyData = "GoodsVarietyData",
    PackageData = "PackageData",
    DiamondData = "DiamondData",
    GoodsRandomDetailData = "GoodsRandomDetailData",
    DBHeroProperty = "DBHeroProperty",
    DBAssembleProperty = "DBAssembleProperty",
    DBPlayerProperty = "DBPlayerProperty",
    DBRaceProperty = "DBRaceProperty",
    DBExclusiveProperty = "DBExclusiveProperty",
    DBBondProperty = "DBBondProperty",
    DBPerk = "DBPerk",
    DBLevelPass = "DBLevelPass",
    DBMainPass = "DBMainPass",
    CollectHeroData = "CollectHeroData",
    DBMedal = "DBMedal",
    SkillData = "SkillData",
    DBHeroEffect = "DBHeroEffect",
    DBHeroExp = "DBHeroExp",
    DBHeroUpgradeData = "DBHeroUpgradeData",
    DBHeroRefines = "DBHeroRefines",
    BulletData = "BulletData",
    DBNormalSummon = "DBNormalSummon",
    DbBlessing = "DbBlessing",
    DbBlessingSub = "DbBlessingSub",
    DBEquip = "DBEquip",
    DBSetEquip = "DBSetEquip",
    DBEquipUpgrade = "DBEquipUpgrade",
    DBEquipDismantle = "DBEquipDismantle",
    DropData = "DropData",
    CurrencyData = "CurrencyData",
    DailyCurrencyData = "DailyCurrencyData",
    HeroData = "HeroData",
    dict_main = "dict_main",
    dict_icon = "dict_icon",

}
// ==================== 数据表映射枚举 ====================

export enum DBSummonTypeEnum {
    HERO = 0,
    MIDDLE = 1,
    EQUIP = 2,
}

